using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;
namespace TallerMecanicoBlazor.Frontend;
public class VehicleService
{
    private readonly HttpClient _http;
    public VehicleService(HttpClient http) => _http = http;

    public async Task<List<VehicleDTO>> GetVehicles()
        => await _http.GetFromJsonAsync<List<VehicleDTO>>("api/Vehicle") ?? new List<VehicleDTO>();

    public async Task<VehicleDTO?> GetVehicleById(int id)
        => await _http.GetFromJsonAsync<VehicleDTO>($"api/Vehicle/{id}");

    public async Task<bool> CreateVehicle(VehicleDTO vehicle)
    {
        var res = await _http.PostAsJsonAsync("api/Vehicle", vehicle);
        return res.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateVehicle(int id, VehicleDTO vehicle)
    {
        var res = await _http.PutAsJsonAsync($"api/Vehicle/{id}", vehicle);
        return res.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteVehicle(int id)
    {
        var res = await _http.DeleteAsync($"api/Vehicle/{id}");
        return res.IsSuccessStatusCode;
    }
}
