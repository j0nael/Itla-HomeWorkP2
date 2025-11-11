using tallermecanico.infretruture.Interfaces;
using tallermecanico.aplication.DTOs;
using Mapster;
using tallermecanico.infretruture.Model;
using tallermecanico.aplication.Contract;

namespace tallermecanico.aplication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerrepositorie _customer;

        public CustomerService(ICustomerrepositorie customer)
        {
            _customer = customer;
        }


        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDto)
        {
            var customer = customerDto.Adapt<CustomerModel>();
            await _customer.CreateCustomerAsync(customer);
            return customerDto;
        }


        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customer.GetAllCustomersAsync();
            return customers.Adapt<List<CustomerDTO>>();
        }


        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customer.GetCustomerByIdAsync(id);
            return customer.Adapt<CustomerDTO>();
        }


        public async Task<CustomerDTO> UpdateCustomerAsync(int id, CustomerDTO customerDto)
        {
            var customer = customerDto.Adapt<CustomerModel>();
            await _customer.UpdateCustomerAsync(id, customer);
            return customerDto;
        }


        public async Task DeleteCustomerAsync(int id)
        {
            await _customer.DeleteCustomerAsync(id);
        }

        public CustomerService() { }
    }
}
