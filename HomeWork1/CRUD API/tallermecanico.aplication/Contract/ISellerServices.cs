using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface ISellerServices
    {
        Task<SellerDTO> CreatesellerAsync(SellerDTO SellerDTO);
        Task DeletesellerAsync(int id);
        Task<List<SellerDTO>> GetAllsellersAsync();
        Task<SellerDTO> GetsellerByIdAsync(int id);
        Task<SellerDTO> UpdatesellerAsync(int id, SellerDTO SellerDTO);
    }
}