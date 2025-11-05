using System;

namespace CRUD_API.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public DateTime Date { get; set; }
    }
}
