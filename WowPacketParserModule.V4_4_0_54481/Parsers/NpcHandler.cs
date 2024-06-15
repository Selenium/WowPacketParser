﻿using System;
using System.Collections.Generic;
using System.Globalization;
using WowPacketParser.DBC;
using WowPacketParser.Enums;
using WowPacketParser.Enums.Version;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;
using WowPacketParser.Proto;
using WowPacketParser.SQL;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;
using CoreParsers = WowPacketParser.Parsing.Parsers;

namespace WowPacketParserModule.V4_4_0_54481.Parsers
{
    public static class NpcHandler
    {
        public static void AddBroadcastTextToGossip(uint menuID, uint broadcastTextID, WowGuid guid)
        {
            NpcText925 npcText = null;
            if (!Storage.GossipToNpcTextMap.TryGetValue(menuID, out npcText))
            {
                npcText = new NpcText925();
                npcText.ObjectType = guid.GetObjectType();
                npcText.ObjectEntry = guid.GetEntry();
                Storage.GossipToNpcTextMap.Add(menuID, npcText);
            }
            npcText.AddBroadcastTextIfNotExists(broadcastTextID, 1.0f);
        }

        public static GossipMessageOption ReadGossipOptionsData(uint menuId, WowGuid npcGuid, Packet packet, params object[] idx)
        {
            GossipMessageOption gossipMessageOption = new();
            GossipMenuOption gossipOption = new GossipMenuOption
            {
                MenuID = menuId
            };

            if (ClientVersion.RemovedInVersion(ClientVersionBuild.V3_4_1_47014))
                gossipOption.OptionID = gossipMessageOption.OptionIndex = (uint)packet.ReadInt32("OptionID", idx);
            else
                gossipOption.GossipOptionID = packet.ReadInt32("GossipOptionID", idx);
            gossipOption.OptionNpc = (GossipOptionNpc?)packet.ReadByte("OptionNPC", idx);
            gossipMessageOption.OptionNpc = (int)gossipOption.OptionNpc;
            gossipOption.BoxCoded = gossipMessageOption.BoxCoded = packet.ReadByte("OptionFlags", idx) != 0;
            gossipOption.BoxMoney = gossipMessageOption.BoxCost = (uint)packet.ReadInt32("OptionCost", idx);
            gossipOption.Language = packet.ReadUInt32E<Language>("Language", idx);

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_4_1_47014))
            {
                gossipOption.Flags = packet.ReadInt32("Flags", idx);
                gossipOption.OptionID = gossipMessageOption.OptionIndex = (uint)packet.ReadInt32("OrderIndex", idx);
            }

            packet.ResetBitReader();
            uint textLen = packet.ReadBits(12);
            uint confirmLen = packet.ReadBits(12);
            bool hasSpellId = false;
            bool hasOverrideIconId = false;
            packet.ReadBits("Status", 2, idx);
            hasSpellId = packet.ReadBit();
            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_4_1_47014))
                hasOverrideIconId = packet.ReadBit();

            uint rewardsCount = packet.ReadUInt32();
            for (uint i = 0; i < rewardsCount; ++i)
            {
                packet.ResetBitReader();
                packet.ReadBits("Type", 1, idx, "TreasureItem", i);
                packet.ReadInt32("ID", idx, "TreasureItem", i);
                packet.ReadInt32("Quantity", idx, "TreasureItem", i);
            }

            gossipOption.OptionText = gossipMessageOption.Text = packet.ReadWoWString("Text", textLen, idx);
            gossipMessageOption.BoxText = packet.ReadWoWString("Confirm", confirmLen, idx);

            if (!string.IsNullOrEmpty(gossipMessageOption.BoxText))
                gossipOption.BoxText = gossipMessageOption.BoxText;

            if (hasSpellId)
                gossipOption.SpellID = packet.ReadInt32("SpellID", idx);

            if (hasOverrideIconId)
                gossipOption.OverrideIconID = packet.ReadInt32("OverrideIconID", idx);

            gossipOption.FillBroadcastTextIDs();

            if (Settings.TargetedDatabase < TargetedDatabase.Shadowlands)
                gossipOption.FillOptionType(npcGuid);

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_4_1_47014))
                Storage.GossipOptionIdToOrderIndexMap.Add((gossipOption.MenuID.GetValueOrDefault(), gossipOption.GossipOptionID.GetValueOrDefault()), gossipOption.OptionID.GetValueOrDefault());
            Storage.GossipMenuOptions.Add((gossipOption.MenuID, gossipOption.OptionID), gossipOption, packet.TimeSpan);

            return gossipMessageOption;
        }

        [HasSniffData]
        [Parser(Opcode.SMSG_GOSSIP_MESSAGE)]
        public static void HandleNpcGossip(Packet packet)
        {
            PacketGossipMessage packetGossip = packet.Holder.GossipMessage = new();

            WowGuid guid = packet.ReadPackedGuid128("GossipGUID");
            packetGossip.GossipSource = guid;

            int menuId = packet.ReadInt32("GossipID");
            packetGossip.MenuId = (uint)menuId;

            int friendshipFactionID = packet.ReadInt32("FriendshipFactionID");
            CoreParsers.NpcHandler.AddGossipAddon(packetGossip.MenuId, friendshipFactionID, guid, packet.TimeSpan);

            uint broadcastTextID = 0;
            uint npcTextID = 0;
            int optionsCount = packet.ReadInt32("GossipOptionsCount");
            int questsCount = packet.ReadInt32("GossipQuestsCount");

            bool hasTextID = false;
            bool hasBroadcastTextID = false;
            hasTextID = packet.ReadBit("HasTextID");
            hasBroadcastTextID = packet.ReadBit("HasBroadcastTextID");

            for (int i = 0; i < optionsCount; ++i)
                packetGossip.Options.Add(ReadGossipOptionsData((uint)menuId, guid, packet, i, "GossipOptions"));

            if (hasTextID)
                npcTextID = (uint)packet.ReadInt32("TextID");

            if (hasBroadcastTextID)
                broadcastTextID = (uint)packet.ReadInt32("BroadcastTextID");

            if (!hasTextID && hasBroadcastTextID)
                npcTextID = SQLDatabase.GetNPCTextIDByMenuIDAndBroadcastText(menuId, broadcastTextID);

            if (npcTextID != 0)
            {
                GossipMenu gossip = new();
                gossip.MenuID = packetGossip.MenuId;
                gossip.TextID = packetGossip.TextId = npcTextID;
                gossip.ObjectType = guid.GetObjectType();
                gossip.ObjectEntry = guid.GetEntry();
                Storage.Gossips.Add(gossip, packet.TimeSpan);
            }
            else if (hasBroadcastTextID)
                AddBroadcastTextToGossip(packetGossip.MenuId, broadcastTextID, guid);

            for (int i = 0; i < questsCount; ++i)
                packetGossip.Quests.Add(V7_0_3_22248.Parsers.NpcHandler.ReadGossipQuestTextData(packet, i, "GossipQuests"));

            if (guid.GetObjectType() == ObjectType.Unit)
            {
                CreatureTemplateGossip creatureTemplateGossip = new()
                {
                    CreatureID = guid.GetEntry(),
                    MenuID = (uint)menuId
                };
                Storage.CreatureTemplateGossips.Add(creatureTemplateGossip);
                Storage.CreatureDefaultGossips.Add(guid.GetEntry(), (uint)menuId);
            }

            CoreParsers.NpcHandler.UpdateLastGossipOptionActionMessage(packet.TimeSpan, (uint)menuId);

            packet.AddSniffData(StoreNameType.Gossip, menuId, guid.GetEntry().ToString(CultureInfo.InvariantCulture));
        }

        [Parser(Opcode.CMSG_GOSSIP_SELECT_OPTION)]
        public static void HandleNpcGossipSelectOption(Packet packet)
        {
            PacketGossipSelect packetGossip = packet.Holder.GossipSelect = new();
            packetGossip.GossipUnit = packet.ReadPackedGuid128("GossipUnit");

            var menuID = packetGossip.MenuId = packet.ReadUInt32("MenuID");
            uint optionID = 0;
            var gossipOptionId = packet.ReadInt32("GossipOptionID");
            Storage.GossipOptionIdToOrderIndexMap.TryGetValue((menuID, gossipOptionId), out optionID);
            packetGossip.OptionId = optionID;

            var bits8 = packet.ReadBits(8);
            packet.ResetBitReader();
            packet.ReadWoWString("PromotionCode", bits8);

            CoreParsers.NpcHandler.LastGossipOption.GossipSelectOption(menuID, optionID, packet.TimeSpan);
            CoreParsers.NpcHandler.TempGossipOptionPOI.GossipSelectOption(menuID, optionID, packet.TimeSpan);
        }

        [Parser(Opcode.SMSG_TRAINER_LIST)]
        public static void HandleServerTrainerList(Packet packet)
        {
            Trainer trainer = new Trainer();

            WowGuid guid = packet.ReadPackedGuid128("TrainerGUID");
            bool hasFaction = false;
            float discount = 1.0f;

            if (Settings.UseDBC && Settings.RecalcDiscount)
                if (Storage.Objects != null && Storage.Objects.ContainsKey(guid))
                {
                    WoWObject obj = Storage.Objects[guid].Item1;
                    if (obj.Type == ObjectType.Unit)
                    {
                        int factionTemplateId = (obj as Unit).UnitData.FactionTemplate ?? 0;
                        int faction = 0;

                        if (factionTemplateId != 0 && DBC.FactionTemplate.ContainsKey(factionTemplateId))
                            faction = DBC.FactionTemplate[factionTemplateId].Faction;

                        ulong reputation = 0;

                        if (CoreParsers.AchievementHandler.FactionReputationStore.ContainsKey(faction))
                        {
                            reputation = CoreParsers.AchievementHandler.FactionReputationStore[faction];
                            hasFaction = true;
                        }

                        uint multiplier = 0;

                        if (reputation >= 3000) // Friendly
                            multiplier = 1;
                        if (reputation >= 9000) // Honored
                            multiplier = 2;
                        if (reputation >= 21000) // Revered
                            multiplier = 3;
                        if (reputation >= 42000) // Exalted
                            multiplier = 4;

                        if (multiplier != 0)
                            discount = 1.0f - 0.05f * multiplier;

                        packet.WriteLine("ReputationDiscount: {0}%", (int)((discount * 100) - 100));
                    }
                }

            trainer.Type = packet.ReadInt32E<TrainerType>("TrainerType");
            trainer.Id = packet.ReadUInt32("TrainerID");

            var count = packet.ReadUInt32("Spells");
            for (var i = 0; i < count; ++i)
            {
                TrainerSpell trainerSpell = new TrainerSpell
                {
                    TrainerId = trainer.Id,
                    SpellId = packet.ReadUInt32<SpellId>("SpellID", i)
                };

                uint moneyCost = packet.ReadUInt32("MoneyCost", i);
                uint moneyCostOriginal = moneyCost;

                if (Settings.UseDBC && Settings.RecalcDiscount && hasFaction)
                {
                    moneyCostOriginal = (uint)(Math.Round((moneyCost / discount) / 5)) * 5;
                    packet.WriteLine("[{0}] MoneyCostOriginal: {1}", i, moneyCostOriginal);
                    trainerSpell.FactionHelper = "MoneyCost recalculated";
                }
                else
                {
                    trainerSpell.FactionHelper = "No Faction found! MoneyCost not recalculated!";
                }

                trainerSpell.MoneyCost = moneyCostOriginal;
                trainerSpell.ReqSkillLine = packet.ReadUInt32("ReqSkillLine", i);
                trainerSpell.ReqSkillRank = packet.ReadUInt32("ReqSkillRank", i);

                trainerSpell.ReqAbility = new uint[3];
                for (var j = 0; j < 3; ++j)
                    trainerSpell.ReqAbility[j] = packet.ReadUInt32("ReqAbility", i, j);

                packet.ReadInt32("Unk440", i);
                packet.ReadByteE<TrainerSpellState>("Usable", i);
                trainerSpell.ReqLevel = packet.ReadByte("ReqLevel", i);

                Storage.TrainerSpells.Add(trainerSpell, packet.TimeSpan);
            }
            packet.ResetBitReader();
            uint greetingLength = packet.ReadBits(11);
            trainer.Greeting = packet.ReadWoWString("Greeting", greetingLength);

            Storage.Trainers.Add(trainer, packet.TimeSpan);
            CoreParsers.NpcHandler.AddToCreatureTrainers(trainer.Id, packet.TimeSpan);
        }

        [Parser(Opcode.CMSG_BANKER_ACTIVATE)]
        [Parser(Opcode.CMSG_BINDER_ACTIVATE)]
        [Parser(Opcode.SMSG_BINDER_CONFIRM)]
        [Parser(Opcode.CMSG_TALK_TO_GOSSIP)]
        [Parser(Opcode.CMSG_LIST_INVENTORY)]
        [Parser(Opcode.CMSG_TRAINER_LIST)]
        public static void HandleNpcHello(Packet packet)
        {
            CoreParsers.NpcHandler.LastGossipOption.Reset();
            CoreParsers.NpcHandler.TempGossipOptionPOI.Reset();
            var guid = CoreParsers.NpcHandler.LastGossipOption.Guid = packet.ReadPackedGuid128("Guid");

            if (packet.Opcode == Opcodes.GetOpcode(Opcode.CMSG_TALK_TO_GOSSIP, Direction.ClientToServer))
                packet.Holder.GossipHello = new PacketGossipHello { GossipSource = guid };
        }
    }
}
