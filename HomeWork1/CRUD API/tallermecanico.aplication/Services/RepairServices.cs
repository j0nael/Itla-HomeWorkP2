using Mapster;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repair;
        private readonly UnitOfWork _unitOfWork;
        public RepairService(IRepairRepository repair,UnitOfWork unitOfWork)
        {
            _repair = repair;
            _unitOfWork = unitOfWork;
        }


        public async Task<RepairDTO> CreaterepairAsync(RepairDTO RepairDTO)
        {
            var repair = RepairDTO.Adapt<RepairModel>();
            await _repair.CreaterepairAsync(repair);
            return RepairDTO;
        }


        public async Task<List<RepairDTO>> GetAllrepairsAsync()
        {
            var repairs = await _repair.GetAllrepairsAsync();
            return repairs.Adapt<List<RepairDTO>>();
        }


        public async Task<RepairDTO> GetrepairByIdAsync(int id)
        {
            var repair = await _repair.GetrepairByIdAsync(id);
            return repair.Adapt<RepairDTO>();
        }


        public async Task<RepairDTO> UpdaterepairAsync(int id, RepairDTO RepairDTO)
        {
            var repair = RepairDTO.Adapt<RepairModel>();
            await _repair.UpdaterepairAsync(id, repair);
            return RepairDTO;
        }


        public async Task DeleterepairAsync(int id)
        {
            await _repair.DeleterepairAsync(id);
        }

        public RepairService() { }
    }
}
