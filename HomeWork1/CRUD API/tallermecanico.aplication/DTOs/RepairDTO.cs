using System;

namespace tallermecanico.aplication.DTOs
{
    public class RepairDTO
    {
        public int RepairId { get; set; }
        public int? VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public int MechanicId { get; set; }
        public int? CustomerId { get; set; }
        public int? InvoiceId { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
    }
}
