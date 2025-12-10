
namespace tallermecanico.aplication.DTOs
{
    public class CustomerDTO
    {
       public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }

    }
}
