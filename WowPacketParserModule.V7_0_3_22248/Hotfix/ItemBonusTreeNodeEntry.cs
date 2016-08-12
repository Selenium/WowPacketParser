using WowPacketParser.Enums;
using WowPacketParser.Hotfix;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.ItemBonusTreeNode, HasIndexInData = false)]
    public class ItemBonusTreeNodeEntry
    {
        public ushort BonusTreeID { get; set; }
        public ushort SubTreeID { get; set; }
        public ushort BonusListID { get; set; }
        public byte BonusTreeModID { get; set; }
    }
}