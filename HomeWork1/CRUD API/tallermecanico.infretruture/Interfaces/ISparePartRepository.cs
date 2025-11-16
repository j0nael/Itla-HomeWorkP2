using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.Interfaces
{
    public interface ISparePartRepository : IBaseRepository<SparePartModel>
    {
        Task CreateSparePartAsync(SparePartModel sparePart);
        Task<List<SparePartModel>> GetAllSparePartsAsync();
        Task<SparePartModel> GetSparePartByIdAsync(int id);
        Task<SparePartModel> UpdateSparePartAsync(int id, SparePartModel sparePart);
        Task<SparePartModel> DeleteSparePartAsync(int id);
    }
}
