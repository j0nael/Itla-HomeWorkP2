namespace tallermecanico.domain.Models.Entityes
{
    public class Item
    {
        public Item() { }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 0;
        public Item(int itemId, int quantity)
        {
            this.ItemId = itemId;
            this.Quantity = quantity;

        }
    }
}
