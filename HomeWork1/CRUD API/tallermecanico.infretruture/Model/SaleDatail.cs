using System.ComponentModel.DataAnnotations;

namespace tallermecanico.infretruture.Model
{
    public class SaleDetailModel
    {
        [Key]
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }
        public SaleModel Sale { get; set; }

        public int SparePartId { get; set; }
        public SparePartModel SparePart { get; set; }

        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal => Quantity * UnitPrice;

        public SaleDetailModel() { }
    }
}
