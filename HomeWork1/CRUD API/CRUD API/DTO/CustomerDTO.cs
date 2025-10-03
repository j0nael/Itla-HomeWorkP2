using CRUD_API.Model.Entyties;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_API.DTO
{
    public class CustomerDTO
    {
        [Column("Customerid")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }

    }
}
