using System.ComponentModel.DataAnnotations;

namespace tallermecanico.domain.Entityes
{
    public class SaleDetail
    {
        [Key]
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; }

        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal => Quantity * UnitPrice;
    }
}
