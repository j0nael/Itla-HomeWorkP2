using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tallermecanico.infretruture.Model
{
    public class VehicleModel
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [MaxLength(30)]
        public string Color { get; set; }

        public int Year { get; set; }

        // FK: Un vehículo pertenece a un cliente
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual CustomerModel Customer { get; set; }

        // Navegación: Un vehículo tiene múltiples reparaciones
        public virtual ICollection<RepairModel> Repairs { get; set; } = new List<RepairModel>();

        public VehicleModel() { }

        public VehicleModel(string licensePlate, string brand, string model, string color, int year, int customerId)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            Color = color;
            Year = year;
            CustomerId = customerId;
        }
    }
}