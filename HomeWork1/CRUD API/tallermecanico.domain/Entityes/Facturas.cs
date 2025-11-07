using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tallermecanico.domain.Entityes
{

    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }
        public int SellerId { get; set; }

       
    }
}
