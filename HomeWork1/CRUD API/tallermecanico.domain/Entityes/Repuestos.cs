using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.domain.Entityes
{
    public class SparePart
    {
        [Key]
        public int SparePartId { get; set; }

        public string Name { get; set; }
        public int InitialQuantity { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double WholesalePrice { get; set; }
        public DateTime EntryDate { get; set; }

       
        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

        public SparePart() { }

        public SparePart(int sparePartId, string name, int quantity, double unitPrice, double wholesalePrice, DateTime entryDate)
        {
            SparePartId = sparePartId;
            Name = name;
            Quantity = quantity;
            InitialQuantity = quantity;
            UnitPrice = unitPrice;
            WholesalePrice = wholesalePrice;
            EntryDate = entryDate;
        }
    }
}
