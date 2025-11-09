using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.infretruture.Model
{
    public class SparePartModel
    {
        [Key]
        public int SparePartId { get; set; }

        public string Name { get; set; }
        public int InitialQuantity { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double WholesalePrice { get; set; }
        public DateTime EntryDate { get; set; }

       
        public List<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel>();

        public SparePartModel() { }

        public SparePartModel(int sparePartId, string name, int quantity, double unitPrice, double wholesalePrice, DateTime entryDate)
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
