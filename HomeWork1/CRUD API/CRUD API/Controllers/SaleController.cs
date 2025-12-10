using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public SaleController(CrudAPIContex context)
        {
            _context = context;
        }

        // ------------------------------------------------------------
        // GET ALL
        // ------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Seller)
                .ToListAsync();

            var list = sales.Select(s => new SaleDTO
            {
                SaleId = s.SaleId,
                CustomerId = s.CustomerId,
                CustomerName = $"{s.Customer.FirstName} {s.Customer.LastName}",
                SellerId = s.SellerId,
                SellerName = $"{s.Seller.FirstName} {s.Seller.LastName}",
                Total = s.Total,
                Date = s.Date,
                InvoiceId = s.InvoiceId
            }).ToList();

            return Ok(list);
        }

        // ------------------------------------------------------------
        // GET BY ID
        // ------------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleById(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Seller)
                .Include(s => s.SaleDetails)
                    .ThenInclude(sd => sd.SparePart)
                .FirstOrDefaultAsync(s => s.SaleId == id);

            if (sale == null)
                return NotFound($"Venta con id {id} no encontrada");

            var saleDTO = new SaleDTO
            {
                SaleId = sale.SaleId,
                CustomerId = sale.CustomerId,
                CustomerName = $"{sale.Customer.FirstName} {sale.Customer.LastName}",
                SellerId = sale.SellerId,
                SellerName = $"{sale.Seller.FirstName} {sale.Seller.LastName}",
                Total = sale.Total,
                Date = sale.Date,
                InvoiceId = sale.InvoiceId
            };

            return Ok(saleDTO);
        }

        // ------------------------------------------------------------
        // CREATE
        // ------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleDTO saleDTO)
        {
            if (!await _context.Customers.AnyAsync(c => c.CustomerId == saleDTO.CustomerId))
                return BadRequest($"El cliente con ID {saleDTO.CustomerId} no existe");

            if (!await _context.Sellers.AnyAsync(s => s.SellerId == saleDTO.SellerId))
                return BadRequest($"El vendedor con ID {saleDTO.SellerId} no existe");

            if (saleDTO.InvoiceId == 0)
                saleDTO.InvoiceId = null;

            var sale = new SaleModel
            {
                CustomerId = saleDTO.CustomerId,
                SellerId = saleDTO.SellerId,
                Total = saleDTO.Total,
                Date = DateTime.Now,
                InvoiceId = saleDTO.InvoiceId
            };

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            saleDTO.SaleId = sale.SaleId;

            return CreatedAtAction(nameof(GetSaleById), new { id = sale.SaleId }, saleDTO);
        }

        // ------------------------------------------------------------
        // UPDATE
        // ------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, [FromBody] SaleDTO saleDTO)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return NotFound($"Venta con id {id} no encontrada");

            if (!await _context.Customers.AnyAsync(c => c.CustomerId == saleDTO.CustomerId))
                return BadRequest($"El cliente con ID {saleDTO.CustomerId} no existe");

            if (!await _context.Sellers.AnyAsync(s => s.SellerId == saleDTO.SellerId))
                return BadRequest($"El vendedor con ID {saleDTO.SellerId} no existe");

            sale.CustomerId = saleDTO.CustomerId;
            sale.SellerId = saleDTO.SellerId;
            sale.Total = saleDTO.Total;
            sale.InvoiceId = saleDTO.InvoiceId;

            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ------------------------------------------------------------
        // DELETE (RESTORES INVENTORY)
        // ------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.SaleDetails)
                    .ThenInclude(sd => sd.SparePart)
                .FirstOrDefaultAsync(s => s.SaleId == id);

            if (sale == null)
                return NotFound($"Venta con id {id} no encontrada");

            // ---------------------------------------------------------------------
            // RESTAURAR INVENTARIO
            // ---------------------------------------------------------------------
            foreach (var detail in sale.SaleDetails)
            {
                detail.SparePart.Quantity += detail.Quantity;
                _context.SpareParts.Update(detail.SparePart);
            }

            // Eliminar detalles
            _context.SaleDetails.RemoveRange(sale.SaleDetails);

            // Eliminar venta
            _context.Sales.Remove(sale);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
