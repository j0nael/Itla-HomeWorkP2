using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.infretruture.Model
{

    public class InvoiceModel
    {
        [Key]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public CustomerModel Customer { get; set; }
        public SellerModel Seller { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public List<SaleModel> Sales { get; set; } = new List<SaleModel>();
        public List<VehicleModel> Vehicles { get; set; } = new List<VehicleModel>();
        public List<RepairModel> Repairs { get; set; } = new List<RepairModel>();

      
        public InvoiceModel() { }

       
        public InvoiceModel(int customerId, int sellerId, List<SaleModel> sales, List<VehicleModel> vehicles, List<RepairModel> repairs)
        {
            this.CustomerId = customerId;
            this.SellerId = sellerId;
            this.Date = DateTime.Now;
            this.Sales = sales ?? new List<SaleModel>();
            this.Vehicles = vehicles ?? new List<VehicleModel>();
            this.Repairs = repairs ?? new List<RepairModel>();
        }
    }
}
