namespace tallermecanico.aplication.DTOs
{
    public class SaleDetailDTO
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int SparePartId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal { get; set; }
    }
}
