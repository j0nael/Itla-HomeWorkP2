using System;
using System.ComponentModel.DataAnnotations;
namespace tallermecanico.infretruture.Model
{
    public class SellerModel
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        // Navegación: Un vendedor realiza múltiples ventas
        public virtual ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

        // Navegación: Un vendedor genera múltiples facturas
        public virtual ICollection<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();

        public SellerModel() { }

        public SellerModel(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}