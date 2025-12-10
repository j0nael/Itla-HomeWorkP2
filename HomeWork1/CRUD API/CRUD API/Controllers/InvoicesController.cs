using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public InvoiceController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Seller)
                .Include(i => i.Sales)
                .Include(i => i.Repairs)
                .ToListAsync();

            var list = invoices.Select(i => new InvoiceDTO
            {
                InvoiceId = i.InvoiceId,
                CustomerId = i.CustomerId,
                CustomerName = $"{i.Customer.FirstName} {i.Customer.LastName}",
                SellerId = i.SellerId,
                SellerName = $"{i.Seller.FirstName} {i.Seller.LastName}",
                Date = i.Date,
                Total = (double)i.Total,
                SalesCount = i.Sales?.Count ?? 0,
                RepairsCount = i.Repairs?.Count ?? 0
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Seller)
                .Include(i => i.Sales)
                    .ThenInclude(s => s.SaleDetails)
                .Include(i => i.Repairs)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            var invoiceDTO = new InvoiceDTO
            {
                InvoiceId = invoice.InvoiceId,
                CustomerId = invoice.CustomerId,
                CustomerName = $"{invoice.Customer.FirstName} {invoice.Customer.LastName}",
                SellerId = invoice.SellerId,
                SellerName = $"{invoice.Seller.FirstName} {invoice.Seller.LastName}",
                Date = invoice.Date,
                Total = (double)invoice.Total,
                SalesCount = invoice.Sales?.Count ?? 0,
                RepairsCount = invoice.Repairs?.Count ?? 0
            };

            return Ok(invoiceDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            // Validar cliente
            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == invoiceDTO.CustomerId);
            if (!customerExists)
            {
                return BadRequest($"El cliente con ID {invoiceDTO.CustomerId} no existe");
            }

            // Validar vendedor
            var sellerExists = await _context.Sellers.AnyAsync(s => s.SellerId == invoiceDTO.SellerId);
            if (!sellerExists)
            {
                return BadRequest($"El vendedor con ID {invoiceDTO.SellerId} no existe");
            }

            var invoice = new InvoiceModel
            {
                CustomerId = invoiceDTO.CustomerId,
                SellerId = invoiceDTO.SellerId,
                Date = DateTime.Now,
                Total = (decimal)invoiceDTO.Total
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            invoiceDTO.InvoiceId = invoice.InvoiceId;
            invoiceDTO.Date = invoice.Date;
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.InvoiceId }, invoiceDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceDTO invoiceDTO)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            // Validar cliente
            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == invoiceDTO.CustomerId);
            if (!customerExists)
            {
                return BadRequest($"El cliente con ID {invoiceDTO.CustomerId} no existe");
            }

            // Validar vendedor
            var sellerExists = await _context.Sellers.AnyAsync(s => s.SellerId == invoiceDTO.SellerId);
            if (!sellerExists)
            {
                return BadRequest($"El vendedor con ID {invoiceDTO.SellerId} no existe");
            }

            invoice.CustomerId = invoiceDTO.CustomerId;
            invoice.SellerId = invoiceDTO.SellerId;
            invoice.Total = (decimal)invoiceDTO.Total;

            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Sales)
                .Include(i => i.Repairs)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            // Las ventas y reparaciones asociadas tendrán su InvoiceId en NULL (SetNull)
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Endpoint para calcular total automáticamente
        [HttpGet("{id}/calculate-total")]
        public async Task<IActionResult> CalculateInvoiceTotal(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Sales)
                    .ThenInclude(s => s.SaleDetails)
                .Include(i => i.Repairs)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            // Calcular total de ventas
            decimal salesTotal = invoice.Sales?
                .SelectMany(s => s.SaleDetails)
                .Sum(sd => sd.Subtotal) ?? 0;

            // Calcular total de reparaciones
            decimal repairsTotal = invoice.Repairs?
                .Sum(r => r.Cost) ?? 0;

            decimal grandTotal = salesTotal + repairsTotal;

            // Actualizar total
            invoice.Total = grandTotal;
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                invoiceId = invoice.InvoiceId,
                salesTotal = (double)salesTotal,
                repairsTotal = (double)repairsTotal,
                grandTotal = (double)grandTotal
            });
        }
    }
}