using WowPacketParser.Misc;
using WowPacketParser.Store.Objects.UpdateFields;

// This file is automatically generated, DO NOT EDIT

namespace WowPacketParserModule.V10_0_0_46181.UpdateFields.V10_2_6_53840
{
    public class CraftingOrderItem : ICraftingOrderItem
    {
        public System.Nullable<ulong> Field_0 { get; set; }
        public WowGuid ItemGUID { get; set; }
        public WowGuid OwnerGUID { get; set; }
        public System.Nullable<int> ItemID { get; set; }
        public System.Nullable<uint> Quantity { get; set; }
        public System.Nullable<int> ReagentQuality { get; set; }
        public System.Nullable<byte> DataSlotIndex { get; set; }
    }
}

