namespace tallermecanico.aplication.DTOs
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? SellerId { get; set; }
        public string SellerName { get; set; }
        public int? InvoiceId { get; set; }
    }
}