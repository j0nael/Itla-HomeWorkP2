using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;

namespace TallerMecanicoBlazor.Frontend
{
    public class VehicleService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public VehicleService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<VehicleDTO>> GetVehicles()
        {
            var result = await _http.GetFromJsonAsync<List<VehicleDTO>>($"{_config.ApiBaseUrl}/api/vehicle");
            return result ?? new List<VehicleDTO>();
        }

        public async Task<VehicleDTO?> GetVehicleById(int id)
        {
            return await _http.GetFromJsonAsync<VehicleDTO>($"{_config.ApiBaseUrl}/api/vehicle/{id}");
        }

        public async Task<bool> CreateVehicle(VehicleDTO vehicle)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/vehicle", vehicle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateVehicle(int id, VehicleDTO vehicle)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/vehicle/{id}", vehicle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/vehicle/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}