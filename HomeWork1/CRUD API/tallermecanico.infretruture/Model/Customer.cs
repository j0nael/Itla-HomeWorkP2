using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace tallermecanico.infretruture.Model
{

    public class CustomerModel

    {
        [Column("CustomerId")]
        public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }


    public List<VehicleModel>?Vehicles { get; set; }

    public List<InvoiceModel> ?Invoices { get; set; }

    public List<RepairModel> ?Repairs { get; set; }

    public List<SparePartModel>? SpareParts { get; set; }

    public CustomerModel(int customerid, string firstName, string phoneNumber, string email, string lastName)
    {
            Id = customerid;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            LastName = lastName;
    }

    public CustomerModel() { }
}

}