using System;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;

namespace WowPacketParserModule.V4_4_0_54481.Parsers
{
    public static class GuildHandler
    {
        public static void ReadGuildRosterMemberData(Packet packet, params object[] idx)
        {
            packet.ReadPackedGuid128("Guid", idx);

            packet.ReadUInt32("RankID", idx);
            packet.ReadUInt32<AreaId>("AreaID", idx);
            packet.ReadUInt32("PersonalAchievementPoints", idx);
            packet.ReadUInt32("GuildReputation", idx);

            packet.ReadSingle("LastSave", idx);

            for (var j = 0; j < 2; ++j)
            {
                packet.ReadUInt32("DbID", idx, j);
                packet.ReadUInt32("Rank", idx, j);
                packet.ReadUInt32("Step", idx, j);
            }

            packet.ReadUInt32("VirtualRealmAddress", idx);
            packet.ReadByteE<GuildMemberFlag>("Status", idx);
            packet.ReadByte("Level", idx);
            packet.ReadByteE<Class>("ClassID", idx);
            packet.ReadByteE<Gender>("Gender", idx);
            packet.ReadUInt64("GuildClubMemberID", idx);
            packet.ReadByte("RaceID", idx);

            packet.ResetBitReader();

            var nameLen = packet.ReadBits(6);
            var noteLen = packet.ReadBits(8);
            var officersNoteLen = packet.ReadBits(8);

            packet.ReadBit("Authenticated", idx);
            packet.ReadBit("SorEligible", idx);

            Substructures.MythicPlusHandler.ReadDungeonScoreSummary(packet, idx, "DungeonScoreSummary");

            packet.ReadWoWString("Name", nameLen, idx);
            packet.ReadWoWString("Note", noteLen, idx);
            packet.ReadWoWString("OfficerNote", officersNoteLen, idx);
        }

        public static void ReadPetitionSignature(Packet packet, params object[] indexes)
        {
            packet.ReadPackedGuid128("Signer", indexes);
            packet.ReadInt32("Choice", indexes);
        }

        [Parser(Opcode.SMSG_ALL_GUILD_ACHIEVEMENTS)]
        public static void HandleGuildAchievementData(Packet packet)
        {
            var earnedAchievementCount = packet.ReadUInt32("EarnedAchievementCount");
            for (var i = 0; i < earnedAchievementCount; ++i)
                AchievementHandler.ReadEarnedAchievement(packet, "Earned", i);
        }

        [Parser(Opcode.CMSG_GUILD_SET_ACHIEVEMENT_TRACKING)]
        public static void HandleGuildSetAchievementTracking(Packet packet)
        {
            var count = packet.ReadUInt32("Count");
            for (var i = 0; i < count; ++i)
                packet.ReadInt32<AchievementId>("AchievementIDs", i);
        }

        [Parser(Opcode.CMSG_QUERY_GUILD_INFO)]
        public static void HandleGuildQuery(Packet packet)
        {
            packet.ReadPackedGuid128("Guild Guid");
            packet.ReadPackedGuid128("Player Guid");
        }

        [Parser(Opcode.SMSG_QUERY_GUILD_INFO_RESPONSE)]
        public static void HandleGuildQueryResponse(Packet packet)
        {
            packet.ReadPackedGuid128("Guild Guid");

            var hasData = packet.ReadBit();
            if (hasData)
            {
                packet.ReadPackedGuid128("GuildGUID");
                packet.ReadInt32("VirtualRealmAddress");
                var rankCount = packet.ReadInt32("RankCount");
                packet.ReadInt32("EmblemColor");
                packet.ReadInt32("EmblemStyle");
                packet.ReadInt32("BorderColor");
                packet.ReadInt32("BorderStyle");
                packet.ReadInt32("BackgroundColor");

                packet.ResetBitReader();
                var nameLen = packet.ReadBits(7);

                for (var i = 0; i < rankCount; i++)
                {
                    packet.ReadInt32("RankID", i);
                    packet.ReadInt32("RankOrder", i);

                    packet.ResetBitReader();
                    var rankNameLen = packet.ReadBits(7);
                    packet.ReadWoWString("Rank Name", rankNameLen, i);
                }

                packet.ReadWoWString("Guild Name", nameLen);
            }
        }

        [Parser(Opcode.SMSG_GUILD_ACHIEVEMENT_DELETED)]
        public static void HandleGuildAchievementDeleted(Packet packet)
        {
            packet.ReadPackedGuid128("GuildGUID");
            packet.ReadUInt32<AchievementId>("AchievementID");
            packet.ReadPackedTime("TimeDeleted");
        }

        [Parser(Opcode.SMSG_GUILD_ACHIEVEMENT_EARNED)]
        public static void HandleGuildAchievementEarned(Packet packet)
        {
            packet.ReadPackedGuid128("GuildGUID");
            packet.ReadUInt32<AchievementId>("AchievementID");
            packet.ReadPackedTime("TimeEarned");
        }

        [Parser(Opcode.SMSG_GUILD_ACHIEVEMENT_MEMBERS)]
        public static void HandleGuildAchievementMembers(Packet packet)
        {
            packet.ReadPackedGuid128("GuildGUID");
            packet.ReadUInt32<AchievementId>("AchievementID");
            var memberCount = packet.ReadUInt32("MemberCount");

            for (int i = 0; i < memberCount; i++)
                packet.ReadPackedGuid128("MemberGUID", i);
        }

        [Parser(Opcode.SMSG_GUILD_BANK_LOG_QUERY_RESULTS)]
        public static void HandleGuildBankLogQueryResult(Packet packet)
        {
            packet.ReadInt32("Tab");
            var guildBankLogEntryCount = packet.ReadInt32("GuildBankLogEntryCount");
            var hasWeeklyBonusMoney = packet.ReadBit("HasWeeklyBonusMoney");

            for (int i = 0; i < guildBankLogEntryCount; i++)
            {
                packet.ReadPackedGuid128("PlayerGUID", i);
                packet.ReadInt32("TimeOffset", i);
                packet.ReadSByte("EntryType", i);

                packet.ResetBitReader();

                var hasMoney = packet.ReadBit("HasMoney", i);
                var hasItemID = packet.ReadBit("HasItemID", i);
                var hasCount = packet.ReadBit("HasCount", i);
                var hasOtherTab = packet.ReadBit("HasOtherTab", i);

                if (hasMoney)
                    packet.ReadInt64("Money", i);

                if (hasItemID)
                    packet.ReadInt32<ItemId>("ItemID", i);

                if (hasCount)
                    packet.ReadInt32("Count", i);

                if (hasOtherTab)
                    packet.ReadSByte("OtherTab", i);
            }

            if (hasWeeklyBonusMoney)
                packet.ReadInt64("WeeklyBonusMoney");
        }

        [Parser(Opcode.SMSG_GUILD_BANK_QUERY_RESULTS)]
        public static void HandleGuildBankQueryResults(Packet packet)
        {
            packet.ReadUInt64("Money");
            packet.ReadInt32("Tab");
            packet.ReadInt32("WithdrawalsRemaining");

            var tabInfoCount = packet.ReadInt32("TabInfoCount");
            var itemInfoCount = packet.ReadInt32("ItemInfoCount");
            packet.ReadBit("FullUpdate");

            for (int i = 0; i < tabInfoCount; i++)
            {
                packet.ReadInt32("TabIndex", i);

                packet.ResetBitReader();

                var nameLength = packet.ReadBits(7);
                var iconLength = packet.ReadBits(9);

                packet.ReadWoWString("Name", nameLength, i);
                packet.ReadWoWString("Icon", iconLength, i);
            }

            for (int i = 0; i < itemInfoCount; i++)
            {
                packet.ReadInt32("Slot", i);

                packet.ReadInt32("Count", i);
                packet.ReadInt32("EnchantmentID", i);
                packet.ReadInt32("Charges", i);
                packet.ReadInt32("OnUseEnchantmentID", i);
                packet.ReadInt32("Flags", i);
                Substructures.ItemHandler.ReadItemInstance(packet, i, "ItemInstance");

                packet.ResetBitReader();
                var socketEnchantmentCount = packet.ReadBits(2);
                packet.ReadBit("Locked", i);

                for (int j = 0; j < socketEnchantmentCount; j++)
                {
                    Substructures.ItemHandler.ReadItemGemData(packet, i, "Gems", j);
                }
            }
        }

        [Parser(Opcode.SMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY)]
        public static void HandleGuildBankMoneyWithdrawnResponse(Packet packet)
        {
            packet.ReadInt64("RemainingWithdrawMoney");
        }

        [Parser(Opcode.SMSG_GUILD_BANK_TEXT_QUERY_RESULT)]
        public static void HandleGuildBankTextQueryResult(Packet packet)
        {
            packet.ReadInt32("Tab");
            var textLength = packet.ReadBits(14);
            packet.ReadWoWString("Text", textLength);
        }

        [Parser(Opcode.SMSG_GUILD_CHALLENGE_UPDATE)]
        public static void HandleGuildChallengeUpdated(Packet packet)
        {
            for (int i = 0; i < 6; ++i)
                packet.ReadInt32("CurrentCount", i);

            for (int i = 0; i < 6; ++i)
                packet.ReadInt32("MaxCount", i);

            for (int i = 0; i < 6; ++i)
                packet.ReadInt32("Gold", i);

            for (int i = 0; i < 6; ++i)
                packet.ReadInt32("MaxLevelGold", i);
        }

        [Parser(Opcode.SMSG_GUILD_COMMAND_RESULT)]
        public static void HandleGuildCommandResult(Packet packet)
        {
            packet.ReadUInt32E<GuildCommandError>("Result");
            packet.ReadUInt32E<GuildCommandType>("Command");
            var len = packet.ReadBits(8);
            packet.ReadWoWString("Name", len);
        }

        [Parser(Opcode.SMSG_GUILD_CRITERIA_DELETED)]
        public static void HandleGuildCriteriaDeleted(Packet packet)
        {
            packet.ReadPackedGuid128("GuildGUID");
            packet.ReadInt32("CriteriaID");
        }

        [Parser(Opcode.SMSG_GUILD_CRITERIA_UPDATE)]
        public static void HandleGuildCriteriaUpdate(Packet packet)
        {
            var progressCount = packet.ReadUInt32("ProgressCount");
            for (int i = 0; i < progressCount; i++)
            {
                packet.ReadInt32("CriteriaID", i);
                packet.ReadTime64("DateCreated", i);
                packet.ReadTime64("DateStarted", i);

                var dateUpdated = packet.ReadInt64();
                packet.AddValue("DateUpdated", Utilities.GetDateTimeFromGameTime((int)dateUpdated), i);

                packet.ReadUInt64("Quantity", i);
                packet.ReadPackedGuid128("PlayerGUID", i);
                packet.ReadInt32("Unused_10_1_5");
                packet.ReadInt32("Flags", i);
            }
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_BANK_MONEY_CHANGED)]
        public static void HandleGuildEventBankMoneyChanged(Packet packet)
        {
            packet.ReadUInt64("Money");
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_LOG_QUERY_RESULTS)]
        public static void HandleGuildEventLogQueryResults(Packet packet)
        {
            var eventCount = packet.ReadInt32("EventEntryCount");
            for (int i = 0; i < eventCount; i++)
            {
                packet.ReadPackedGuid128("PlayerGUID", i);
                packet.ReadPackedGuid128("OtherGUID", i);
                packet.ReadByte("TransactionType", i);
                packet.ReadByte("RankID", i);
                packet.ReadUInt32("TransactionDate", i);
            }
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_MOTD)]
        public static void HandleGuildEventMotd(Packet packet)
        {
            var motdLen = packet.ReadBits(11);
            packet.ReadWoWString("MotdText", motdLen);
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_NEW_LEADER)]
        public static void HandleGuildEventNewLeader(Packet packet)
        {
            packet.ReadBit("SelfPromoted");
            var oldLeaderNameLength = packet.ReadBits(6);
            var newLeaderNameLength = packet.ReadBits(6);
            packet.ReadPackedGuid128("OldLeaderGUID");
            packet.ReadUInt32("OldLeaderVirtualRealmAddress");
            packet.ReadPackedGuid128("NewLeaderGUID");
            packet.ReadUInt32("NewLeaderVirtualRealmAddress");
            packet.ReadWoWString("OldLeaderName", oldLeaderNameLength);
            packet.ReadWoWString("NewLeaderName", newLeaderNameLength);
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_PLAYER_JOINED)]
        public static void HandleGuildEventPlayerJoined(Packet packet)
        {
            packet.ReadPackedGuid128("Guid");
            packet.ReadInt32("VirtualRealmAddress");

            var len = packet.ReadBits(6);
            packet.ReadWoWString("Name", len);
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_PLAYER_LEFT)]
        public static void HandleGuildEventPlayerLeft(Packet packet)
        {
            var hasRemoved = packet.ReadBit("Removed");
            var lenLeaverName = packet.ReadBits(6);

            if (hasRemoved)
            {
                var lenRemoverName = packet.ReadBits(6);
                packet.ReadPackedGuid128("RemoverGUID");
                packet.ReadInt32("RemoverVirtualRealmAddress");
                packet.ReadWoWString("RemoverName", lenRemoverName);
            }

            packet.ReadPackedGuid128("LeaverGUID");
            packet.ReadInt32("LeaverVirtualRealmAddress");
            packet.ReadWoWString("LeaverName", lenLeaverName);
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_PRESENCE_CHANGE)]
        public static void HandleGuildEventPresenceChange(Packet packet)
        {
            packet.ReadPackedGuid128("Guid");
            packet.ReadInt32("VirtualRealmAddress");

            packet.ResetBitReader();
            var nameLength = packet.ReadBits(6);
            packet.ReadBit("LoggedOn");
            packet.ReadBit("Mobile");

            packet.ReadWoWString("Name", nameLength);
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_RANK_CHANGED)]
        public static void HandleGuildEventRankChanged(Packet packet)
        {
            packet.ReadInt32("RankID");
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_TAB_MODIFIED)]
        public static void HandleGuildEventTabModified(Packet packet)
        {
            packet.ReadInt32("Tab");

            var nameLength = packet.ReadBits("NameLength", 7);
            var iconLength = packet.ReadBits("IconLength", 9);
            packet.ResetBitReader();

            packet.ReadWoWString("Name", nameLength);
            packet.ReadWoWString("Icon", iconLength);
        }

        [Parser(Opcode.SMSG_GUILD_EVENT_TAB_TEXT_CHANGED)]
        public static void HandleGuildEventTabTextChanged(Packet packet)
        {
            packet.ReadInt32("Tab");
        }

        [Parser(Opcode.SMSG_GUILD_FLAGGED_FOR_RENAME)]
        public static void HandleGuildFlaggedForRename(Packet packet)
        {
            packet.ReadBit("FlagSet");
        }

        [Parser(Opcode.SMSG_GUILD_INVITE)]
        public static void HandleGuildInvite(Packet packet)
        {
            var inviterNameLength = packet.ReadBits(6);
            var oldGuildNameLength = packet.ReadBits(7);
            var guildNameLength = packet.ReadBits(7);

            packet.ReadInt32("InviterVirtualRealmAddress");
            packet.ReadUInt32("GuildVirtualRealmAddress");
            packet.ReadPackedGuid128("GuildGUID");
            packet.ReadUInt32("OldGuildVirtualRealmAddress");
            packet.ReadPackedGuid128("OldGuildGUID");
            packet.ReadUInt32("EmblemStyle");
            packet.ReadUInt32("EmblemColor");
            packet.ReadUInt32("BorderStyle");
            packet.ReadUInt32("BorderColor");
            packet.ReadUInt32("Background");
            packet.ReadUInt32("AchievementPoints");

            packet.ReadWoWString("InviterName", inviterNameLength);
            packet.ReadWoWString("OldGuildName", oldGuildNameLength);
            packet.ReadWoWString("GuildName", guildNameLength);
        }

        [Parser(Opcode.SMSG_GUILD_MEMBER_UPDATE_NOTE)]
        public static void HandleGuildMemberUpdateNotes(Packet packet)
        {
            packet.ReadPackedGuid128("MemberGUID");
            var noteLength = packet.ReadBits(8);
            packet.ReadBit("IsPublic");
            packet.ReadWoWString("Note", noteLength);
        }

        [Parser(Opcode.SMSG_GUILD_NAME_CHANGED)]
        public static void HandleGuildNameChanged(Packet packet)
        {
            packet.ReadPackedGuid128("GuildGUID");

            var len = packet.ReadBits(7);
            packet.ReadWoWString("GuildName", len);
        }

        [Parser(Opcode.SMSG_GUILD_NEWS)]
        public static void HandleGuildUpdateRoster(Packet packet)
        {
            var count = packet.ReadInt32("NewsCount");

            for (var i = 0; i < count; ++i)
            {
                packet.ReadInt32("Id", i);
                packet.ReadPackedTime("CompletedDate", i);
                packet.ReadInt32("Type", i);
                packet.ReadInt32("Flags", i);

                for (var j = 0; j < 2; ++j)
                    packet.ReadInt32("Data", i, j);

                packet.ReadPackedGuid128("MemberGuid", i);

                var memberListCount = packet.ReadInt32("MemberListCount", i);

                for (var j = 0; j < memberListCount; ++j)
                    packet.ReadPackedGuid128("MemberList", i, j);

                packet.ResetBitReader();

                var hasItem = packet.ReadBit();
                if (hasItem)
                    Substructures.ItemHandler.ReadItemInstance(packet, i);
            }
        }

        [Parser(Opcode.SMSG_GUILD_PARTY_STATE)]
        public static void HandleGuildPartyStateResponse(Packet packet)
        {
            packet.ReadBit("InGuildParty");
            packet.ReadUInt32("NumMembers");
            packet.ReadUInt32("NumRequired");
            packet.ReadSingle("GuildXPEarnedMult");
        }

        [Parser(Opcode.SMSG_GUILD_PERMISSIONS_QUERY_RESULTS)]
        public static void HandleGuildPermissionsQueryResult(Packet packet)
        {
            packet.ReadInt32("RankID");
            packet.ReadUInt32E<GuildRankRightsFlag>("Flags");
            packet.ReadInt32("WithdrawGoldLimit");
            packet.ReadUInt32("NumTabs");

            var tabCount = packet.ReadInt32("TabCount");

            for (var i = 0; i < tabCount; i++)
            {
                packet.ReadInt32E<GuildBankRightsFlag>("Flags", i);
                packet.ReadInt32("WithdrawItemLimit", i);
            }
        }

        [Parser(Opcode.SMSG_GUILD_RANKS)]
        public static void HandleGuildRankServer434(Packet packet)
        {
            var count = packet.ReadUInt32("Count");

            for (var i = 0; i < count; ++i)
            {
                packet.ReadByte("RankID", i);
                packet.ReadInt32("RankOrder", i);
                packet.ReadInt32("Flags", i);
                packet.ReadInt32("WithdrawGoldLimit", i);

                for (var j = 0; j < 8; ++j)
                {
                    packet.ReadInt32E<GuildBankRightsFlag>("TabFlags", i, j);
                    packet.ReadInt32("TabWithdrawItemLimit", i, j);
                }

                packet.ResetBitReader();
                var rankNameLength = (int)packet.ReadBits(7);
                packet.ReadWoWString("RankName", rankNameLength, i);
            }
        }

        [Parser(Opcode.SMSG_GUILD_REWARD_LIST)]
        public static void HandleGuildRewardsList(Packet packet)
        {
            packet.ReadTime64("Version");

            var size = packet.ReadUInt32("RewardItemsCount");
            for (int i = 0; i < size; i++)
            {
                packet.ReadUInt32<ItemId>("ItemID", i);
                packet.ReadUInt32("Unk4", i);
                var achievementReqCount = packet.ReadInt32("AchievementsRequiredCount", i);
                packet.ReadUInt64("RaceMask", i);
                packet.ReadInt32("MinGuildLevel", i);
                packet.ReadInt32("MinGuildRep", i);
                packet.ReadInt64("Cost", i);

                for (int j = 0; j < achievementReqCount; j++)
                    packet.ReadInt32("AchievementsRequired", i, j);
            }
        }

        [Parser(Opcode.SMSG_GUILD_ROSTER)]
        public static void HandleGuildRoster(Packet packet)
        {
            packet.ReadUInt32("NumAccounts");
            packet.ReadPackedTime("CreateDate");
            packet.ReadUInt32("GuildFlags");
            var int20 = packet.ReadUInt32("MemberDataCount");

            packet.ResetBitReader();
            var welcomeTextLen = packet.ReadBits(11);
            var infoTextLen = packet.ReadBits(11);

            for (var i = 0; i < int20; ++i)
                ReadGuildRosterMemberData(packet, "MemberData", i);

            packet.ReadWoWString("WelcomeText", welcomeTextLen);
            packet.ReadWoWString("InfoText", infoTextLen);
        }

        [Parser(Opcode.SMSG_GUILD_ROSTER_UPDATE)]
        public static void HandleGuildRosterUpdate(Packet packet)
        {
            var memberDataCount = packet.ReadUInt32();
            for (var i = 0; i < memberDataCount; ++i)
                ReadGuildRosterMemberData(packet, "MemberData", i);
        }

        [Parser(Opcode.SMSG_GUILD_SEND_RANK_CHANGE)]
        public static void HandleGuildRanksUpdate(Packet packet)
        {
            packet.ReadPackedGuid128("Officer");
            packet.ReadPackedGuid128("Other");
            packet.ReadInt32("RankID");
            packet.ReadBit("Promote");
        }

        [Parser(Opcode.SMSG_OFFER_PETITION_ERROR)]
        public static void HandlePetitionError(Packet packet)
        {
            packet.ReadGuid("PetitionGUID");
        }

        [Parser(Opcode.SMSG_PETITION_ALREADY_SIGNED)]
        public static void HandlePetitionAlreadySigned(Packet packet)
        {
            packet.ReadPackedGuid128("SignerGUID");
        }

        [Parser(Opcode.SMSG_PETITION_RENAME_GUILD_RESPONSE)]
        public static void HandlePetitionRenameGuildResponse(Packet packet)
        {
            packet.ReadPackedGuid128("PetitionGuid");
            packet.ResetBitReader();
            var length = packet.ReadBits(7);

            packet.ReadWoWString("NewGuildName", length);
        }

        [Parser(Opcode.SMSG_PETITION_SHOW_LIST)]
        public static void HandlePetitionShowList(Packet packet)
        {
            packet.ReadPackedGuid128("GUID");
            var counter = packet.ReadUInt32("Counter");
            for (var i = 0; i < counter; i++)
            {
                packet.ReadUInt32("Index");
                packet.ReadUInt32("CharterCost");
                packet.ReadUInt32("CharterEntry");
                packet.ReadUInt32("Unk440");
                packet.ReadUInt32("RequiredSigns");
            }
        }

        [Parser(Opcode.SMSG_PETITION_SHOW_SIGNATURES)]
        public static void HandlePetitionShowSignatures(Packet packet)
        {
            packet.ReadPackedGuid128("Item");
            packet.ReadPackedGuid128("Owner");
            packet.ReadPackedGuid128("OwnerWoWAccount");
            packet.ReadInt32("PetitionID");

            var signaturesCount = packet.ReadInt32("SignaturesCount");
            for (int i = 0; i < signaturesCount; i++)
                ReadPetitionSignature(packet, i, "PetitionSignature");
        }

        [Parser(Opcode.SMSG_PETITION_SIGN_RESULTS)]
        public static void HandlePetitionSignResults(Packet packet)
        {
            packet.ReadPackedGuid128("Item");
            packet.ReadPackedGuid128("Player");
            packet.ReadBits("Error", 4);
        }

        [Parser(Opcode.SMSG_PLAYER_SAVE_GUILD_EMBLEM)]
        public static void HandlePlayerSaveGuildEmblem(Packet packet)
        {
            packet.ReadInt32E<GuildEmblemError>("Error");
        }

        [Parser(Opcode.CMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY_QUERY)]
        [Parser(Opcode.SMSG_GUILD_EVENT_BANK_CONTENTS_CHANGED)]
        [Parser(Opcode.SMSG_GUILD_EVENT_DISBANDED)]
        [Parser(Opcode.SMSG_GUILD_EVENT_RANKS_UPDATED)]
        [Parser(Opcode.SMSG_GUILD_EVENT_TAB_ADDED)]
        [Parser(Opcode.SMSG_GUILD_MEMBER_DAILY_RESET)]
        public static void HandleGuildZero(Packet packet)
        {
        }
    }
}
