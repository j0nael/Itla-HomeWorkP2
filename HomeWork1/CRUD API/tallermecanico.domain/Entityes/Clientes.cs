using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tallermecanico.domain.Entityes
{

    public class Customer
    {
        [Column("CustomerId")]
  
        public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }


    public List<Vehicle>?Vehicles { get; set; }

    public List<Invoice> ?Invoices { get; set; }

    public List<Repair> ?Repairs { get; set; }

    public List<SparePart>? SpareParts { get; set; }

    public Customer(int customerid, string firstName, string phoneNumber, string email, string lastName)
    {
            Id = customerid;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            LastName = lastName;
    }

    public Customer() { }
}

}