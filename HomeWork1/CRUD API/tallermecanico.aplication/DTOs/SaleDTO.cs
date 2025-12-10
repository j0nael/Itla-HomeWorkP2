using System;
using System.Collections.Generic;

namespace tallermecanico.aplication.DTOs
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int SellerId { get; set; }
        public string SellerName { get; set; } = string.Empty;
        public int? InvoiceId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public List<SaleDetailDTO> SaleDetails { get; set; } = new();
    }
}
