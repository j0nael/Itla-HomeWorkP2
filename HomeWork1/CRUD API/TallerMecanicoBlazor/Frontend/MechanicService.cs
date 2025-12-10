using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class MechanicService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public MechanicService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<MechanicDTO>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<MechanicDTO>>($"{_config.ApiBaseUrl}/api/mechanic");
            return result ?? new List<MechanicDTO>();
        }

        public async Task<MechanicDTO?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<MechanicDTO>($"{_config.ApiBaseUrl}/api/mechanic/{id}");
        }

        public async Task<bool> CreateAsync(MechanicDTO mechanic)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/mechanic", mechanic);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, MechanicDTO mechanic)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/mechanic/{id}", mechanic);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/mechanic/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}