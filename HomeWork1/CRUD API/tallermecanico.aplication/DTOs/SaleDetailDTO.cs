using System.ComponentModel.DataAnnotations;

namespace tallermecanico.aplication.DTOs
{
    public class SaleDetailDTO
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }

        [Required]
        public int SparePartId { get; set; }
        public string SparePartName { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public decimal Subtotal => Quantity * UnitPrice;
    }
}
