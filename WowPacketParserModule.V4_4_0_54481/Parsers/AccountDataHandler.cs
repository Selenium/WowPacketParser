﻿using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;

namespace WowPacketParserModule.V4_4_0_54481.Parsers
{
    public static class AccountDataHandler
    {
        public static void ReadAccountCharacterList(Packet packet, params object[] idx)
        {
            packet.ReadPackedGuid128("WowAccountGUID", idx);
            packet.ReadPackedGuid128("CharacterGUID", idx);
            packet.ReadUInt32("VirtualRealmAddress", idx);
            packet.ReadByteE<Race>("Race" ,idx);
            packet.ReadByteE<Class>("Class", idx);
            packet.ReadByteE<Gender>("Gender", idx);
            packet.ReadByte("Level", idx);
            packet.ReadTime64("LastLogin", idx);
            packet.ReadUInt32("Unk440", idx);

            packet.ResetBitReader();

            uint characterNameLength = packet.ReadBits(6);
            uint realmNameLength = packet.ReadBits(9);

            packet.ReadWoWString("CharacterName", characterNameLength, idx);
            packet.ReadWoWString("RealmName", realmNameLength, idx);
        }

        [Parser(Opcode.SMSG_GET_ACCOUNT_CHARACTER_LIST_RESULT)]
        public static void HandleGetAccountCharacterListResult(Packet packet)
        {
            packet.ReadUInt32("Token");
            uint count = packet.ReadUInt32("CharacterCount");

            packet.ResetBitReader();

            packet.ReadBit("UnkBit");

            for (var i = 0; i < count; ++i)
            {
                ReadAccountCharacterList(packet, i);
            }
        }

        [Parser(Opcode.SMSG_CACHE_INFO)]
        public static void HandleCacheInfo(Packet packet)
        {
            var cacheInfoCount = packet.ReadUInt32("CacheInfoCount");

            packet.ResetBitReader();

            var signatureLen = packet.ReadBits(6);

            for (var i = 0; i < cacheInfoCount; ++i)
            {
                packet.ResetBitReader();

                var variableNameLen = packet.ReadBits(6);
                var valueLen = packet.ReadBits(6);

                packet.WriteLine($"[{i.ToString()}] VariableName: \"{packet.ReadWoWString((int)variableNameLen)}\" Value: \"{packet.ReadWoWString((int)valueLen)}\"");
            }

            packet.ReadWoWString("Signature", signatureLen);
        }
    }
}
