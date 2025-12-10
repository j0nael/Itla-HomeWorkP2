using System;

namespace tallermecanico.aplication.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int SalesCount { get; set; }
        public int RepairsCount { get; set; }
    }
}