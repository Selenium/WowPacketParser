// <auto-generated>
// DO NOT EDIT
// </auto-generated>

using System.CodeDom.Compiler;
using WowPacketParser.Misc;
using WowPacketParser.Store.Objects.UpdateFields;

namespace WowPacketParserModule.V11_0_0_55666.UpdateFields.V11_0_0_55666
{
    [GeneratedCode("UpdateFieldCodeGenerator.Formats.WowPacketParserHandler", "1.0.0.0")]
    public class CorpseData : ICorpseData
    {
        public System.Nullable<uint> DynamicFlags { get; set; }
        public WowGuid Owner { get; set; }
        public WowGuid PartyGUID { get; set; }
        public WowGuid GuildGUID { get; set; }
        public System.Nullable<uint> DisplayID { get; set; }
        public System.Nullable<uint>[] Items { get; } = new System.Nullable<uint>[19];
        public System.Nullable<byte> RaceID { get; set; }
        public System.Nullable<byte> Sex { get; set; }
        public System.Nullable<byte> Class { get; set; }
        public System.Nullable<uint> Flags { get; set; }
        public System.Nullable<int> FactionTemplate { get; set; }
        public System.Nullable<uint> StateSpellVisualKitID { get; set; }
        public DynamicUpdateField<IChrCustomizationChoice> Customizations { get; } = new DynamicUpdateField<IChrCustomizationChoice>();
    }
}

