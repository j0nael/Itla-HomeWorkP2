using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class SaleDetailService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public SaleDetailService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<SaleDetailDTO>> GetBySaleIdAsync(int saleId)
        {
            return await _http.GetFromJsonAsync<List<SaleDetailDTO>>
                ($"{_config.ApiBaseUrl}/api/saledetail/by-sale/{saleId}")
                ?? new List<SaleDetailDTO>();
        }

        public async Task<bool> AddDetailAsync(SaleDetailDTO detail)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/saledetail", detail);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDetailAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/saledetail/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
