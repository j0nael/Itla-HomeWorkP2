using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<VehicleModel>
    {
        Task CreateVehicleAsync(VehicleModel vehicle);
        Task<List<VehicleModel>> GetAllVehiclesAsync();
        Task<VehicleModel> GetVehicleByIdAsync(int id);
        Task<VehicleModel> UpdateVehicleAsync(int id, VehicleModel vehicle);
        Task<VehicleModel> DeleteVehicleAsync(int id);
    }
}
