using tallermecanico.infretruture.Model;


namespace tallermecanico.infretruture.Interfaces
{
    public interface IMechanicrepositorie : IBaseRepository<MechanicModel>
    {
        Task CreatemechanicAsync(MechanicModel mechanic);
        Task<List<MechanicModel>> GetAllmechanicsAsync();
        Task<MechanicModel> GetmechanicByIdAsync(int id);
        Task<MechanicModel> UpdatemechanicAsync(int id, MechanicModel mechanic);
        Task<MechanicModel> DeletemechanicAsync(int id);
    }
}
