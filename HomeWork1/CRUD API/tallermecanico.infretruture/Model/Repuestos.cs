using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tallermecanico.infretruture.Model
{
    public class SparePartModel
    {
        [Key]
        public int SparePartId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int InitialQuantity { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WholesalePrice { get; set; }

        public DateTime EntryDate { get; set; } = DateTime.Now;

        // Navegación
        public virtual ICollection<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel>();

        public SparePartModel() { }

        public SparePartModel(string name, int quantity, decimal unitPrice, decimal wholesalePrice)
        {
            Name = name;
            Quantity = quantity;
            InitialQuantity = quantity;
            UnitPrice = unitPrice;
            WholesalePrice = wholesalePrice;
        }
    }
}