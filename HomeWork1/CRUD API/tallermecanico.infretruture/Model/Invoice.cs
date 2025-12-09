using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tallermecanico.infretruture.Model
{

    public class InvoiceModel
    {
        [Key]
        public int InvoiceId { get; set; }

        // FK: Una factura pertenece a un cliente
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual CustomerModel Customer { get; set; }

        // FK: Una factura es generada por un vendedor
        [Required]
        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public virtual SellerModel Seller { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        // Navegación: Una factura incluye múltiples ventas
        public virtual ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

        // Navegación: Una factura incluye múltiples reparaciones
        public virtual ICollection<RepairModel> Repairs { get; set; } = new List<RepairModel>();

        public InvoiceModel() { }

        public InvoiceModel(int customerId, int sellerId)
        {
            CustomerId = customerId;
            SellerId = sellerId;
        }
    }
}
