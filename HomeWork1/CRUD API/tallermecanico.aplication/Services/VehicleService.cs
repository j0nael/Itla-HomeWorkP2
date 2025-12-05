using Mapster;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicle;
        private readonly UnitOfWork _unitOfWork;
        public VehicleService(IVehicleRepository vehicle,UnitOfWork unitOfWork)
        {
            _vehicle = vehicle;
            _unitOfWork = unitOfWork;
        }

        public async Task<VehicleDTO> CreateVehicleAsync(VehicleDTO vehicleDto)
        {
            var vehicle = vehicleDto.Adapt<VehicleModel>();
            await _vehicle.CreateVehicleAsync(vehicle);
            return vehicleDto;
        }

        public async Task<List<VehicleDTO>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicle.GetAllVehiclesAsync();
            return vehicles.Adapt<List<VehicleDTO>>();
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _vehicle.GetVehicleByIdAsync(id);
            return vehicle.Adapt<VehicleDTO>();
        }

        public async Task<VehicleDTO> UpdateVehicleAsync(int id, VehicleDTO vehicleDto)
        {
            var vehicle = vehicleDto.Adapt<VehicleModel>();
            await _vehicle.UpdateVehicleAsync(id, vehicle);
            return vehicleDto;
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _vehicle.DeleteVehicleAsync(id);
        }

        public VehicleService() { }
    }
}
