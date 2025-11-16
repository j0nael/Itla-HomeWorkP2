using tallermecanico.infretruture.Model;


namespace tallermecanico.infretruture.Interfaces
{
    public interface IRepairRepository : IBaseRepository<RepairModel>
    {
        Task CreaterepairAsync(RepairModel repair);
        Task<List<RepairModel>> GetAllrepairsAsync();
        Task<RepairModel> GetrepairByIdAsync(int id);
        Task<RepairModel> UpdaterepairAsync(int id, RepairModel repair);
        Task<RepairModel> DeleterepairAsync(int id);
    }
}
