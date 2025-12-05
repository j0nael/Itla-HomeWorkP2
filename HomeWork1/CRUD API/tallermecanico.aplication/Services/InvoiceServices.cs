using Mapster;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class Invoiceservices : IInvoiceservices
    {
        private readonly IInvoiceRepository _invoice;
        private readonly UnitOfWork _unitOfWork;
        public Invoiceservices(IInvoiceRepository invoice,UnitOfWork unitOfWork)
        {
            _invoice = invoice;
            _unitOfWork = unitOfWork;
        }


        public async Task<InvoiceDTO> CreateinvoiceAsync(InvoiceDTO InvoiceDTO)
        {
            var invoice = InvoiceDTO.Adapt<InvoiceModel>();
            await _invoice.CreateinvoiceAsync(invoice);
            return InvoiceDTO;
        }


        public async Task<List<InvoiceDTO>> GetAllinvoicesAsync()
        {
            var invoices = await _invoice.GetAllinvoicesAsync();
            return invoices.Adapt<List<InvoiceDTO>>();
        }


        public async Task<InvoiceDTO> GetinvoiceByIdAsync(int id)
        {
            var invoice = await _invoice.GetinvoiceByIdAsync(id);
            return invoice.Adapt<InvoiceDTO>();
        }


        public async Task<InvoiceDTO> UpdateinvoiceAsync(int id, InvoiceDTO InvoiceDTO)
        {
            var invoice = InvoiceDTO.Adapt<InvoiceModel>();
            await _invoice.UpdateinvoiceAsync(id, invoice);
            return InvoiceDTO;
        }


        public async Task DeleteinvoiceAsync(int id)
        {
            await _invoice.DeleteinvoiceAsync(id);
        }

        public Invoiceservices() { }
    }
}
