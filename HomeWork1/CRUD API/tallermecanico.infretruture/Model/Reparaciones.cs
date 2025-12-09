using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tallermecanico.infretruture.Model
{
  
  public class RepairModel
    {
        [Key]
        public int RepairId { get; set; }

        // FK: Una reparación pertenece a un vehículo
        [Required]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public virtual VehicleModel Vehicle { get; set; }

        // FK: Una reparación es realizada por un mecánico
        [Required]
        public int MechanicId { get; set; }

        [ForeignKey(nameof(MechanicId))]
        public virtual MechanicModel Mechanic { get; set; }

        // FK: Una reparación puede estar en una factura (opcional)
        public int? InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public virtual InvoiceModel Invoice { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public RepairModel() { }

        public RepairModel(int vehicleId, int mechanicId, string description, decimal cost)
        {
            VehicleId = vehicleId;
            MechanicId = mechanicId;
            Description = description;
            Cost = cost;
        }
    }
}