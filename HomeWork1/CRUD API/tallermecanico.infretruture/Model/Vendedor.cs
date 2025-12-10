using System.Collections.Generic;
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

        // Navegación
        public virtual ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();
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