using System;
using System.ComponentModel.DataAnnotations;
namespace tallermecanico.infretruture.Model 
{
    public class RepairModel
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
        public VehicleModel Vehicle { get; set; }

        public CustomerModel Customer { get; set; }

        public InvoiceModel Invoice { get; set; }

        public MechanicModel Mechanic { get; set; }

       // public List<Service> Services { get; set; } = new List<Service>();


        public RepairModel() { }

        public RepairModel(int repairId, int customerId, int vehicleId, int mechanicId, string description, double cost,string linceseplate)
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