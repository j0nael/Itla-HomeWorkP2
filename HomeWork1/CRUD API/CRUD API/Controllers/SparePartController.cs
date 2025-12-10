using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SparePartController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public SparePartController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpareParts()
        {
            var spareParts = await _context.SpareParts.ToListAsync();
            var list = spareParts.Select(sp => new SparePartDTO
            {
                SparePartId = sp.SparePartId,
                Name = sp.Name,
                InitialQuantity = sp.InitialQuantity,
                Quantity = sp.Quantity,
                UnitPrice = sp.UnitPrice,
                WholesalePrice = (double)sp.WholesalePrice,
                EntryDate = sp.EntryDate
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSparePartById(int id)
        {
            var sparePart = await _context.SpareParts.FirstOrDefaultAsync(sp => sp.SparePartId == id);
            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            var sparePartDTO = new SparePartDTO
            {
                SparePartId = sparePart.SparePartId,
                Name = sparePart.Name,
                InitialQuantity = sparePart.InitialQuantity,
                Quantity = sparePart.Quantity,
                UnitPrice =sparePart.UnitPrice,
                WholesalePrice = (double)sparePart.WholesalePrice,
                EntryDate = sparePart.EntryDate
            };

            return Ok(sparePartDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSparePart([FromBody] SparePartDTO sparePartDTO)
        {
            if (string.IsNullOrWhiteSpace(sparePartDTO.Name))
            {
                return BadRequest("El nombre del repuesto es obligatorio");
            }

            if (sparePartDTO.Quantity < 0)
            {
                return BadRequest("La cantidad no puede ser negativa");
            }

            if (sparePartDTO.UnitPrice <= 0)
            {
                return BadRequest("El precio unitario debe ser mayor a 0");
            }

            var sparePart = new SparePartModel
            {
                Name = sparePartDTO.Name,
                InitialQuantity = sparePartDTO.Quantity,
                Quantity = sparePartDTO.Quantity,
                UnitPrice = (decimal)sparePartDTO.UnitPrice,
                WholesalePrice = (decimal)sparePartDTO.WholesalePrice,
                EntryDate = DateTime.Now
            };

            _context.SpareParts.Add(sparePart);
            await _context.SaveChangesAsync();

            sparePartDTO.SparePartId = sparePart.SparePartId;
            sparePartDTO.EntryDate = sparePart.EntryDate;
            return CreatedAtAction(nameof(GetSparePartById), new { id = sparePart.SparePartId }, sparePartDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSparePart(int id, [FromBody] SparePartDTO sparePartDTO)
        {
            var sparePart = await _context.SpareParts.FirstOrDefaultAsync(sp => sp.SparePartId == id);
            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            if (sparePartDTO.Quantity < 0)
            {
                return BadRequest("La cantidad no puede ser negativa");
            }

            sparePart.Name = sparePartDTO.Name;
            sparePart.Quantity = sparePartDTO.Quantity;
            sparePart.UnitPrice = (decimal)sparePartDTO.UnitPrice;
            sparePart.WholesalePrice = (decimal)sparePartDTO.WholesalePrice;

            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSparePart(int id)
        {
            var sparePart = await _context.SpareParts
                .Include(sp => sp.SaleDetails)
                .FirstOrDefaultAsync(sp => sp.SparePartId == id);

            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            // Verificar si está en uso
            if (sparePart.SaleDetails != null && sparePart.SaleDetails.Any())
            {
                return BadRequest($"No se puede eliminar el repuesto porque está en {sparePart.SaleDetails.Count} venta(s)");
            }

            _context.SpareParts.Remove(sparePart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Endpoint adicional para agregar stock
        [HttpPost("{id}/add-stock")]
        public async Task<IActionResult> AddStock(int id, [FromBody] int quantity)
        {
            var sparePart = await _context.SpareParts.FirstOrDefaultAsync(sp => sp.SparePartId == id);
            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            if (quantity <= 0)
            {
                return BadRequest("La cantidad debe ser mayor a 0");
            }

            sparePart.Quantity += quantity;
            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Stock actualizado. Cantidad actual: {sparePart.Quantity}" });
        }
    }
}