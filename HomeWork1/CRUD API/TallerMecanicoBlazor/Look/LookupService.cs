using System.Net.Http.Json;
using tallermecanico.aplication.DTOs;
namespace TallerMecanicoBlazor.Look
{
    

    public class LookupService
    {
        private readonly HttpClient _http;
        public LookupService(HttpClient http) => _http = http;

        // Customers: reutiliza el CustomerDTO que ya tienes en backend
        public async Task<List<CustomerLookupDto>> GetCustomers()
        {
            var customers = await _http.GetFromJsonAsync<List<CustomerLookupDto>>("api/customer");
            return customers ?? new List<CustomerLookupDto>();
        }

        // Sellers (asume endpoint api/seller que devuelve SellerLookupDto)
        public async Task<List<SellerLookupDto>> GetSellers()
        {
            var sellers = await _http.GetFromJsonAsync<List<SellerLookupDto>>("api/seller");
            return sellers ?? new List<SellerLookupDto>();
        }

        // Invoices (asume endpoint api/invoice que devuelve InvoiceLookupDto)
        public async Task<List<InvoiceLookupDto>> GetInvoices()
        {
            var invoices = await _http.GetFromJsonAsync<List<InvoiceLookupDto>>("api/invoice");
            return invoices ?? new List<InvoiceLookupDto>();
        }
    }

    // Lookup DTOs (put these in /Models or the same file)
    public class CustomerLookupDto
    {
        public int Id { get; set; }    // coincide con tu backend
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Helper property para mostrar nombre completo:
        public string FullName => $"{FirstName} {LastName}";
    }

    public class SellerLookupDto
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
    }

    public class InvoiceLookupDto
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
    }

}
