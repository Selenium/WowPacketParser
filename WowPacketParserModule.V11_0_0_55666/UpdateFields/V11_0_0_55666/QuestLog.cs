// <auto-generated>
// DO NOT EDIT
// </auto-generated>

using System.CodeDom.Compiler;
using WowPacketParser.Misc;
using WowPacketParser.Store.Objects.UpdateFields;

namespace WowPacketParserModule.V11_0_0_55666.UpdateFields.V11_0_0_55666
{
    [GeneratedCode("UpdateFieldCodeGenerator.Formats.WowPacketParserHandler", "1.0.0.0")]
    public class QuestLog : IQuestLog
    {
        public System.Nullable<long> EndTime { get; set; }
        public System.Nullable<int> QuestID { get; set; }
        public System.Nullable<uint> StateFlags { get; set; }
        public System.Nullable<uint> ObjectiveFlags { get; set; }
        public System.Nullable<short>[] ObjectiveProgress { get; } = new System.Nullable<short>[24];
    }
}

