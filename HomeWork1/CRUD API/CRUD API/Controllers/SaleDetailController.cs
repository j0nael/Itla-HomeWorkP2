using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleDetailController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public SaleDetailController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSaleDetails()
        {
            var saleDetails = await _context.SaleDetails
                .Include(sd => sd.Sale)
                .Include(sd => sd.SparePart)
                .ToListAsync();

            var list = saleDetails.Select(sd => new SaleDetailDTO
            {
                SaleDetailId = sd.SaleDetailId,
                SaleId = sd.SaleId,
                SparePartId = sd.SparePartId,
                SparePartName = sd.SparePart.Name,
                Quantity = sd.Quantity,
                UnitPrice = sd.UnitPrice
                // Subtotal se calcula automáticamente en DTO
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleDetailById(int id)
        {
            var saleDetail = await _context.SaleDetails
                .Include(sd => sd.Sale)
                .Include(sd => sd.SparePart)
                .FirstOrDefaultAsync(sd => sd.SaleDetailId == id);

            if (saleDetail == null)
            {
                return NotFound($"Detalle de venta con id {id} no encontrado");
            }

            var saleDetailDTO = new SaleDetailDTO
            {
                SaleDetailId = saleDetail.SaleDetailId,
                SaleId = saleDetail.SaleId,
                SparePartId = saleDetail.SparePartId,
                SparePartName = saleDetail.SparePart.Name,
                Quantity = saleDetail.Quantity,
                UnitPrice = saleDetail.UnitPrice
                // Subtotal se calcula automáticamente
            };

            return Ok(saleDetailDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSaleDetail([FromBody] SaleDetailDTO saleDetailDTO)
        {
            // Validar que la venta exista
            var saleExists = await _context.Sales.AnyAsync(s => s.SaleId == saleDetailDTO.SaleId);
            if (!saleExists)
                return BadRequest($"La venta con ID {saleDetailDTO.SaleId} no existe");

            // Validar que el repuesto exista
            var sparePart = await _context.SpareParts.FirstOrDefaultAsync(sp => sp.SparePartId == saleDetailDTO.SparePartId);
            if (sparePart == null)
                return BadRequest($"El repuesto con ID {saleDetailDTO.SparePartId} no existe");

            // Validar cantidad disponible
            if (sparePart.Quantity < saleDetailDTO.Quantity)
                return BadRequest($"Stock insuficiente. Disponible: {sparePart.Quantity}, Solicitado: {saleDetailDTO.Quantity}");

            var saleDetail = new SaleDetailModel
            {
                SaleId = saleDetailDTO.SaleId,
                SparePartId = saleDetailDTO.SparePartId,
                Quantity = saleDetailDTO.Quantity,
                UnitPrice = saleDetailDTO.UnitPrice
            };

            // Reducir cantidad de stock
            sparePart.Quantity -= saleDetailDTO.Quantity;

            _context.SaleDetails.Add(saleDetail);
            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();

            // No asignar Subtotal manualmente
            saleDetailDTO.SaleDetailId = saleDetail.SaleDetailId;
            return CreatedAtAction(nameof(GetSaleDetailById), new { id = saleDetail.SaleDetailId }, saleDetailDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSaleDetail(int id, [FromBody] SaleDetailDTO saleDetailDTO)
        {
            var saleDetail = await _context.SaleDetails
                .Include(sd => sd.SparePart)
                .FirstOrDefaultAsync(sd => sd.SaleDetailId == id);

            if (saleDetail == null)
                return NotFound($"Detalle de venta con id {id} no encontrado");

            // Restaurar cantidad anterior al stock
            var sparePart = saleDetail.SparePart;
            sparePart.Quantity += saleDetail.Quantity;

            // Validar nueva cantidad disponible
            if (sparePart.Quantity < saleDetailDTO.Quantity)
                return BadRequest($"Stock insuficiente. Disponible: {sparePart.Quantity}, Solicitado: {saleDetailDTO.Quantity}");

            // Actualizar detalle
            saleDetail.Quantity = saleDetailDTO.Quantity;
            saleDetail.UnitPrice = (decimal)saleDetailDTO.UnitPrice;

            // Reducir nueva cantidad del stock
            sparePart.Quantity -= saleDetailDTO.Quantity;

            _context.SaleDetails.Update(saleDetail);
            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleDetail(int id)
        {
            var saleDetail = await _context.SaleDetails
                .Include(sd => sd.SparePart)
                .FirstOrDefaultAsync(sd => sd.SaleDetailId == id);

            if (saleDetail == null)
                return NotFound($"Detalle de venta con id {id} no encontrado");

            // Restaurar cantidad al stock
            var sparePart = saleDetail.SparePart;
            sparePart.Quantity += saleDetail.Quantity;

            _context.SaleDetails.Remove(saleDetail);
            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
