using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class SparePartService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public SparePartService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<SparePartDTO>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<SparePartDTO>>($"{_config.ApiBaseUrl}/api/sparepart");
            return result ?? new List<SparePartDTO>();
        }

        public async Task<SparePartDTO?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<SparePartDTO>($"{_config.ApiBaseUrl}/api/sparepart/{id}");
        }

        public async Task<bool> CreateAsync(SparePartDTO dto)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/sparepart", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, SparePartDTO dto)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/sparepart/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/sparepart/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
