using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_API.Model.Entyties
{
    public class Customer
    {

        [Column("Customerid")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
      
    }
}
