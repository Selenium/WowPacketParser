// <auto-generated>
// DO NOT EDIT
// </auto-generated>

using System.CodeDom.Compiler;
using WowPacketParser.Misc;
using WowPacketParser.Store.Objects.UpdateFields;

namespace WowPacketParserModule.V11_0_0_55666.UpdateFields.V11_0_2_55959
{
    [GeneratedCode("UpdateFieldCodeGenerator.Formats.WowPacketParserHandler", "1.0.0.0")]
    public class StableInfo : IStableInfo
    {
        public WowGuid StableMaster { get; set; }
        public DynamicUpdateField<IStablePetInfo> Pets { get; } = new DynamicUpdateField<IStablePetInfo>();
    }
}

