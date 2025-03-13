namespace InventorySystem
{
    [System.Serializable]
    public class InventorySlot
    {
        public ItemData Item { get; }
        public int Quantity { get; set; }

        public InventorySlot(ItemData item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}