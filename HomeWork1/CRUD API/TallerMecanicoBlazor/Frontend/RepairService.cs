using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class RepairService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public RepairService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<RepairDTO>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<RepairDTO>>($"{_config.ApiBaseUrl}/api/repair");
            return result ?? new List<RepairDTO>();
        }

        public async Task<RepairDTO?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<RepairDTO>($"{_config.ApiBaseUrl}/api/repair/{id}");
        }

        public async Task<bool> CreateAsync(RepairDTO repair)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/repair", repair);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, RepairDTO repair)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/repair/{id}", repair);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/repair/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}