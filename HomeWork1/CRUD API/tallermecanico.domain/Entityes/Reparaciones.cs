using System;
using System.ComponentModel.DataAnnotations;
namespace tallermecanico.domain.Entityes 
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public int MechanicId { get; set; }

        public int CustomerId { get; set; }

        public int? InvoiceId { get; set; }

        public string Description { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; } 
        
    }
}