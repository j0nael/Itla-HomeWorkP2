using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface ISparePartService
    {
        Task<SparePartDTO> CreateSparePartAsync(SparePartDTO sparePartDto);
        Task<List<SparePartDTO>> GetAllSparePartsAsync();
        Task<SparePartDTO> GetSparePartByIdAsync(int id);
        Task<SparePartDTO> UpdateSparePartAsync(int id, SparePartDTO sparePartDto);
        Task DeleteSparePartAsync(int id);
    }
}
