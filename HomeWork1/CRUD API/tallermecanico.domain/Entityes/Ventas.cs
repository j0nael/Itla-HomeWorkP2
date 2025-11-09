using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.domain.Entityes
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public double Total { get; set; }
        public DateTime Date { get; set; } 

        
    }
}
