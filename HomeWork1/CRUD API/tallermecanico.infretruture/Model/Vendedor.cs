using System;
using System.ComponentModel.DataAnnotations;
namespace tallermecanico.infretruture.Model 
{
    public class SellerModel
    {
        [Key]
        public int SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<VehicleModel>? Vehicles { get; set; }

        public List<RepairModel>? Repairs { get; set; }
        public List<SparePartModel>? SpareParts { get; set; }

        public List<InvoiceModel>? Invoices { get; set; }

        public SellerModel() { }

        public SellerModel(int sellerId, string firstName, string lastName, string email, string phoneNumber)
        {
            SellerId = sellerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}