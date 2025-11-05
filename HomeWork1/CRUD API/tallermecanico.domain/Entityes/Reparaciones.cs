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
        public Vehicle Vehicle { get; set; }

        public Customer Customer { get; set; }

        public Invoice Invoice { get; set; }

        public Mechanic Mechanic { get; set; }

       // public List<Service> Services { get; set; } = new List<Service>();


        public Repair() { }

        public Repair(int repairId, int customerId, int vehicleId, int mechanicId, string description, double cost,string linceseplate)
        {
            RepairId = repairId;
            CustomerId = customerId;
            VehicleId = vehicleId;
            MechanicId = mechanicId;
            Description = description;
            Cost = cost;
            LicensePlate = linceseplate;
           

        }
    }
}