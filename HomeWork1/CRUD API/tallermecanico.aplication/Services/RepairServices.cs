using tallermecanico.infretruture.Interfaces;
using tallermecanico.aplication.DTOs;
using Mapster;
using tallermecanico.infretruture.Model;
using tallermecanico.aplication.Contract;

namespace tallermecanico.aplication.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repair;

        public RepairService(IRepairRepository repair)
        {
            _repair = repair;
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
