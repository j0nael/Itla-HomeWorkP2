using System;

namespace tallermecanico.aplication.DTOs
{
    public class VehicleDTO
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public int CustomerId { get; set; }
        public int? SellerId { get; set; }
        public int? InvoiceId { get; set; }
    }
}
