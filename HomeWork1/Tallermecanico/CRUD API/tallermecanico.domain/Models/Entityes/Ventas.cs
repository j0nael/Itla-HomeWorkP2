using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.domain.Models.Entityes
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public double Total { get; set; }
        public DateTime Date { get; set; } 

        public Customer Customer { get; set; }
        public Seller Seller { get; set; }

       
        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

        public Sale() { }

        public Sale(int customerId, int sellerId)
        {
            this.CustomerId = customerId;
            this.SellerId = sellerId;
            this.Date = DateTime.Now;
        }
    }
}
