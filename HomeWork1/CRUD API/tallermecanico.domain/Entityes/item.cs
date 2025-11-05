namespace tallermecanico.domain.Entityes
{
    public class Item
    {
        public Item() { }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 0;
        public Item(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;

        }
    }
}
