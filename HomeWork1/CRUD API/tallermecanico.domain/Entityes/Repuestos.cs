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

       
       
    }
}
