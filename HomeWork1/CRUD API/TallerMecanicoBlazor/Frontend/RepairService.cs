using System.Net.Http;
using System.Net.Http.Json;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;


namespace TallerMecanicoBlazor.Frontend
{
    
        public class RepairService 
        {
            private readonly HttpClient _http;

            public RepairService(HttpClient http)
            {
                _http = http;
            }

            public async Task<List<RepairDTO>> GetAllAsync()
            {
                return await _http.GetFromJsonAsync<List<RepairDTO>>("api/Repair");
            }

            public async Task<RepairDTO?> GetByIdAsync(int id)
            {
                return await _http.GetFromJsonAsync<RepairDTO>($"api/Repair/{id}");
            }

            public async Task<bool> CreateAsync(RepairDTO repair)
            {
                var response = await _http.PostAsJsonAsync("api/Repair", repair);
                return response.IsSuccessStatusCode;
            }

            public async Task<bool> UpdateAsync(int id, RepairDTO repair)
            {
                var response = await _http.PutAsJsonAsync($"api/Repair/{id}", repair);
                return response.IsSuccessStatusCode;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var response = await _http.DeleteAsync($"api/Repair/{id}");
                return response.IsSuccessStatusCode;
            }
        }
    }


