using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface ISaleServices
    {
        Task<SaleDTO> CreatesaleAsync(SaleDTO SaleDTO);
        Task DeletesaleAsync(int id);
        Task<List<SaleDTO>> GetAllsalesAsync();
        Task<SaleDTO> GetsaleByIdAsync(int id);
        Task<SaleDTO> UpdatesaleAsync(int id, SaleDTO SaleDTO);
    }
}