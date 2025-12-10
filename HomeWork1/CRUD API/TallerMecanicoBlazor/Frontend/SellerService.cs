using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class SellerService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public SellerService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<SellerDTO>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<SellerDTO>>($"{_config.ApiBaseUrl}/api/seller");
            return result ?? new List<SellerDTO>();
        }

        public async Task<SellerDTO?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<SellerDTO>($"{_config.ApiBaseUrl}/api/seller/{id}");
        }

        public async Task<bool> CreateAsync(SellerDTO seller)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/seller", seller);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, SellerDTO seller)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/seller/{id}", seller);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/seller/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
