using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface IVehicleService
    {
        Task<VehicleDTO> CreateVehicleAsync(VehicleDTO vehicleDto);
        Task<List<VehicleDTO>> GetAllVehiclesAsync();
        Task<VehicleDTO> GetVehicleByIdAsync(int id);
        Task<VehicleDTO> UpdateVehicleAsync(int id, VehicleDTO vehicleDto);
        Task DeleteVehicleAsync(int id);
    }
}
