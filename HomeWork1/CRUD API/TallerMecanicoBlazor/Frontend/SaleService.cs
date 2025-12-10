using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class SaleService
    {
        private readonly HttpClient _http;

        public SaleService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SaleDTO>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<SaleDTO>>("api/sale");
        }

        public async Task<SaleDTO> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<SaleDTO>($"api/sale/{id}");
        }

        public async Task<SaleDTO> CreateAsync(SaleDTO sale)
        {
            var response = await _http.PostAsJsonAsync("api/sale", sale);
            return await response.Content.ReadFromJsonAsync<SaleDTO>();
        }


        public async Task UpdateAsync(int id, SaleDTO sale)
        {
            await _http.PutAsJsonAsync($"api/sale/{id}", sale);
        }

        public async Task DeleteAsync(int id)
        {
            await _http.DeleteAsync($"api/sale/{id}");
        }
    }
}
