using WowPacketParser.Enums;
using WowPacketParser.Hotfix;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.ItemBagFamily, HasIndexInData = false)]
    public class ItemBagFamilyEntry
    {
        public string Name { get; set; }
    }
}