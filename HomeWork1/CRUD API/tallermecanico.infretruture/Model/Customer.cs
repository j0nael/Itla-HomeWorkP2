using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tallermecanico.infretruture.Model
{
    public class CustomerModel
    {
        [Key]
      
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        // Navegación
        public virtual ICollection<VehicleModel> Vehicles { get; set; } = new List<VehicleModel>();
        public virtual ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();
        public virtual ICollection<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();

        public CustomerModel() { }

        public CustomerModel(string firstName, string lastName, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}