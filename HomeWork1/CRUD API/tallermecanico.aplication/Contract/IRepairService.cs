using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface IRepairService
    {
        Task<RepairDTO> CreaterepairAsync(RepairDTO RepairDTO);
        Task DeleterepairAsync(int id);
        Task<List<RepairDTO>> GetAllrepairsAsync();
        Task<RepairDTO> GetrepairByIdAsync(int id);
        Task<RepairDTO> UpdaterepairAsync(int id, RepairDTO RepairDTO);
    }
}