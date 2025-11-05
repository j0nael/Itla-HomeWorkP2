using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.domain.Models.Entityes
{

    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public Customer Customer { get; set; }
        public Seller Seller { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public List<Sale> Sales { get; set; } = new List<Sale>();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<Repair> Repairs { get; set; } = new List<Repair>();

      
        public Invoice() { }

       
        public Invoice(int customerId, int sellerId, List<Sale> sales, List<Vehicle> vehicles, List<Repair> repairs)
        {
            this.CustomerId = customerId;
            this.SellerId = sellerId;
            this.Date = DateTime.Now;
            this.Sales = sales ?? new List<Sale>();
            this.Vehicles = vehicles ?? new List<Vehicle>();
            this.Repairs = repairs ?? new List<Repair>();
        }
    }
}
