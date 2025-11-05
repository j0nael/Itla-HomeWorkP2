using System;

namespace tallermecanico.aplication.DTOs
{
    public class SaleDTO
    {
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
