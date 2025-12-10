using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tallermecanico.infretruture.Model
{
    public class SaleDetailModel
    {
        [Key]
        public int SaleDetailId { get; set; }

        // FK: Detalle pertenece a una venta
        [Required]
        public int SaleId { get; set; }

        [ForeignKey(nameof(SaleId))]
        public virtual SaleModel Sale { get; set; }

        // FK: Detalle referencia una pieza
        [Required]
        public int SparePartId { get; set; }

        [ForeignKey(nameof(SparePartId))]
        public virtual SparePartModel SparePart { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal Subtotal => Quantity * UnitPrice;

        public SaleDetailModel() { }

        public SaleDetailModel(int saleId, int sparePartId, int quantity, decimal unitPrice)
        {
            SaleId = saleId;
            SparePartId = sparePartId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}