using tallermecanico.aplication.DTOs;

namespace tallermecanico.aplication.Contract
{
    public interface IInvoiceservices
    {
        Task<InvoiceDTO> CreateinvoiceAsync(InvoiceDTO InvoiceDTO);
        Task DeleteinvoiceAsync(int id);
        Task<List<InvoiceDTO>> GetAllinvoicesAsync();
        Task<InvoiceDTO> GetinvoiceByIdAsync(int id);
        Task<InvoiceDTO> UpdateinvoiceAsync(int id, InvoiceDTO InvoiceDTO);
    }
}