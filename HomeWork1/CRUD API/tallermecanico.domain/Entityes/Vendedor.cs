using System;
using System.ComponentModel.DataAnnotations;
namespace tallermecanico.domain.Entityes 
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

       
    }
}