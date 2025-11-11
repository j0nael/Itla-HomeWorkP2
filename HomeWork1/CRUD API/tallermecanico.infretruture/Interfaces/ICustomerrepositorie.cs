using tallermecanico.infretruture.Model;
{
    
}

namespace tallermecanico.infretruture.Interfaces
{
    public interface ICustomerrepositorie : IBaserepositorie<CustomerModel>
    {
        Task CreateCustomerAsync(CustomerModel customer);
        Task<List<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel> GetCustomerByIdAsync(int id);
        Task<CustomerModel> UpdateCustomerAsync(int id, CustomerModel customer);
        Task<CustomerModel> DeleteCustomerAsync(int id);
    }
}
