using System;

namespace tallermecanico.aplication.DTOs
{
    public class SparePartDTO
    {
        public int SparePartId { get; set; }
        public string Name { get; set; }
        public int InitialQuantity { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double WholesalePrice { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
