using tallermecanico.aplication.DTOs;
namespace TallerMecanicoBlazor.Frontend
{

    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAll();
        Task<CustomerDTO?> GetById(int id);
        Task<bool> Create(CustomerDTO customer);
        Task<bool> Update(int id, CustomerDTO customer);
        Task<bool> Delete(int id);
    }

}
