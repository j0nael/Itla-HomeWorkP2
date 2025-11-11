using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDto);
        Task DeleteCustomerAsync(int id);
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<CustomerDTO> UpdateCustomerAsync(int id, CustomerDTO customerDto);
    }
}