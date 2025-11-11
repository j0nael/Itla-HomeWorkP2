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
       
    }
}
