﻿using System;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;

namespace WowPacketParserModule.V5_4_0_17359.Parsers
{
    public static class CombatLogHandler
    {
        [Parser(Opcode.SMSG_SPELLNONMELEEDAMAGELOG)]
        public static void HandleSpellNonMeleeDmgLog(Packet packet)
        {
            var target = new byte[8];
            var caster = new byte[8];
            var powerTargetGUID = new byte[8];

            packet.ReadUInt32("Damage");
            packet.ReadUInt32("Resist");
            packet.ReadEnum<AttackerStateFlags>("Attacker State Flags", TypeCode.Int32);
            packet.ReadUInt32("Blocked");
            packet.ReadEntryWithName<UInt32>(StoreNameType.Spell, "Spell ID");
            packet.ReadInt32("Overkill");
            packet.ReadUInt32("Absorb");
            packet.ReadByte("SchoolMask");

            var hasDebugOutput = packet.ReadBit("Has Debug Output");
            packet.StartBitStream(caster, 1, 7);
            target[1] = packet.ReadBit();

            var bit2C = false;
            var bit10 = false;
            var bit1C = false;
            var bit24 = false;
            var bit20 = false;
            var bit34 = false;
            var bit18 = false;
            var bit14 = false;
            var bit28 = false;
            var bit30 = false;
            if (hasDebugOutput)
            {
                bit2C = !packet.ReadBit();
                bit10 = !packet.ReadBit();
                bit1C = !packet.ReadBit();
                bit24 = !packet.ReadBit();
                bit20 = !packet.ReadBit();
                bit34 = !packet.ReadBit();
                bit18 = !packet.ReadBit();
                bit14 = !packet.ReadBit();
                bit28 = !packet.ReadBit();
                bit30 = !packet.ReadBit();
            }

            packet.ReadBit("bit44");
            packet.StartBitStream(target, 5, 0, 3, 6, 2);
            packet.StartBitStream(caster, 6, 5, 4);
            var hasPawerData = packet.ReadBit();

            var bits8C = 0u;
            if (hasPawerData)
            {
                packet.StartBitStream(powerTargetGUID, 1, 5, 7, 4, 6, 3);
                bits8C = packet.ReadBits(21);
                packet.StartBitStream(powerTargetGUID, 2, 0);
            }

            target[7] = packet.ReadBit();
            caster[3] = packet.ReadBit();
            target[4] = packet.ReadBit();
            packet.StartBitStream(caster, 0, 2);
            packet.ReadBit("bit50");
            packet.ResetBitReader();

            if (hasDebugOutput)
            {
                if (bit28)
                    packet.ReadSingle("float28");
                if (bit20)
                    packet.ReadSingle("float20");
                if (bit24)
                    packet.ReadSingle("float24");
                if (bit1C)
                    packet.ReadSingle("float1C");
                if (bit30)
                    packet.ReadSingle("float30");
                if (bit18)
                    packet.ReadSingle("float18");
                if (bit14)
                    packet.ReadSingle("float14");
                if (bit10)
                    packet.ReadSingle("float10");
                if (bit2C)
                    packet.ReadSingle("float2C");
                if (bit34)
                    packet.ReadSingle("float34");
            }

            packet.ReadXORByte(caster, 7);
            if (hasPawerData)
            {
                packet.ReadXORByte(powerTargetGUID, 3);
                packet.ReadInt32("Attack Power");
                packet.ReadXORBytes(powerTargetGUID, 5, 1, 7);
                for (var i = 0; i < bits8C; ++i)
                {
                    packet.ReadInt32("Value", i);
                    packet.ReadEnum<PowerType>("Power type", TypeCode.UInt32, i);
                }

                packet.ReadXORBytes(powerTargetGUID, 4, 0);
                packet.ReadInt32("Current Health");
                packet.ReadXORByte(powerTargetGUID, 6);
                packet.ReadInt32("Spell power");
                packet.ReadXORByte(powerTargetGUID, 2);
                packet.WriteGuid("Power Target GUID", powerTargetGUID);
            }

            packet.ReadXORBytes(target, 2, 1);
            packet.ReadXORByte(caster, 1);
            packet.ReadXORBytes(target, 4, 7);
            packet.ReadXORByte(caster, 6);
            packet.ReadXORByte(target, 5);
            packet.ReadXORBytes(caster, 2, 3);
            packet.ReadXORByte(target, 6);
            packet.ReadXORBytes(caster, 0, 4, 5);
            packet.ReadXORBytes(target, 3, 0);

            packet.WriteGuid("CasterGUID", caster);
            packet.WriteGuid("TargetGUID", target);
        }
    }
}
