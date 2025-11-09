using Microsoft.AspNetCore.Mvc;
using tallermecanico.domain.Entityes;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public InvoiceController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/Invoice
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _aPIContex.Invoices.ToList();
            var list = invoices.Select(i => new InvoiceDTO
            {
                InvoiceId = i.InvoiceId,
                CustomerId = i.CustomerId,
                SellerId = i.SellerId,
                Date = i.Date
            }).ToList();

            return Ok(list);
        }

        // GET: api/Invoice/{id}
        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _aPIContex.Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            var invoiceDTO = new InvoiceDTO
            {
                InvoiceId = invoice.InvoiceId,
                CustomerId = invoice.CustomerId,
                SellerId = invoice.SellerId,
                Date = invoice.Date
            };

            return Ok(invoiceDTO);
        }

        // POST: api/Invoice
        [HttpPost]
        public IActionResult CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            var invoicedb = new InvoiceModel
            {
                CustomerId = invoiceDTO.CustomerId,
                SellerId = invoiceDTO.SellerId,
                Date = DateTime.Now
            };

            _aPIContex.Invoices.Add(invoicedb);
            _aPIContex.SaveChanges();

            return Ok(invoiceDTO);
        }

        // PUT: api/Invoice/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id, [FromBody] InvoiceDTO invoiceDTO)
        {
            var invoice = _aPIContex.Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            invoice.CustomerId = invoiceDTO.CustomerId;
            invoice.SellerId = invoiceDTO.SellerId;
            invoice.Date = invoiceDTO.Date;

            _aPIContex.Invoices.Update(invoice);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Invoice/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = _aPIContex.Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound($"Factura con id {id} no encontrada");
            }

            _aPIContex.Invoices.Remove(invoice);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
