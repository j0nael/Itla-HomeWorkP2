using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface IMechanicServices
    {
        Task<MechanicDTO> CreatemechanicAsync(MechanicDTO MechanicDTO);
        Task DeletemechanicAsync(int id);
        Task<List<MechanicDTO>> GetAllmechanicsAsync();
        Task<MechanicDTO> GetmechanicByIdAsync(int id);
        Task<MechanicDTO> UpdatemechanicAsync(int id, MechanicDTO MechanicDTO);
    }
}