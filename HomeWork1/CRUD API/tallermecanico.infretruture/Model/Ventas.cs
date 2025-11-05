using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.infretruture.Model
{
    public class SaleModel
    {
        [Key]
        public int SaleId { get; set; }

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public double Total { get; set; }
        public DateTime Date { get; set; } 

        public CustomerModel Customer { get; set; }
        public SellerModel Seller { get; set; }

       
        public List<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel>();

        public SaleModel() { }

        public SaleModel(int customerId, int sellerId)
        {
            CustomerId = customerId;
            SellerId = sellerId;
            Date = DateTime.Now;
        }
    }
}
