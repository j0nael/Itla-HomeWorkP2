using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.Interfaces
{
    public interface IInvoiceRepository : IBaseRepository<InvoiceModel>
    {
        Task CreateinvoiceAsync(InvoiceModel invoice);
        Task<List<InvoiceModel>> GetAllinvoicesAsync();
        Task<InvoiceModel> GetinvoiceByIdAsync(int id);
        Task<InvoiceModel> UpdateinvoiceAsync(int id, InvoiceModel invoice);
        Task<InvoiceModel> DeleteinvoiceAsync(int id);
    }
}
