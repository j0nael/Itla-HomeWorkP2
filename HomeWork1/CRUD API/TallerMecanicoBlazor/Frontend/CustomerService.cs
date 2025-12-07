
using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend

{
    
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public CustomerService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<CustomerDTO>> GetAll()
        {
            var result = await _http.GetFromJsonAsync<List<CustomerDTO>>($"{_config.ApiBaseUrl}/customer");
            return result ?? new List<CustomerDTO>();
        }

        public async Task<CustomerDTO?> GetById(int id)
        {
            return await _http.GetFromJsonAsync<CustomerDTO>($"{_config.ApiBaseUrl}/customer/{id}");
        }

        public async Task<bool> Create(CustomerDTO customer)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/customer", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, CustomerDTO customer)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/customer/{id}", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/customer/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
