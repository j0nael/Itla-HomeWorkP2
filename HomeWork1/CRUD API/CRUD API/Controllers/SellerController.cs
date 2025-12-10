using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public SellerController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSellers()
        {
            var sellers = await _context.Sellers.ToListAsync();
            var list = sellers.Select(s => new SellerDTO
            {
                SellerId = s.SellerId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSellerById(int id)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id);
            if (seller == null)
            {
                return NotFound($"Vendedor con id {id} no encontrado");
            }

            var sellerDTO = new SellerDTO
            {
                SellerId = seller.SellerId,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Email = seller.Email,
                PhoneNumber = seller.PhoneNumber
            };

            return Ok(sellerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeller([FromBody] SellerDTO sellerDTO)
        {
            // Validación de email duplicado
            if (!string.IsNullOrEmpty(sellerDTO.Email))
            {
                var emailExists = await _context.Sellers.AnyAsync(s => s.Email == sellerDTO.Email);
                if (emailExists)
                {
                    return BadRequest($"El email {sellerDTO.Email} ya está registrado");
                }
            }

            var seller = new SellerModel
            {
                FirstName = sellerDTO.FirstName,
                LastName = sellerDTO.LastName,
                Email = sellerDTO.Email,
                PhoneNumber = sellerDTO.PhoneNumber
            };

            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();

            sellerDTO.SellerId = seller.SellerId;
            return CreatedAtAction(nameof(GetSellerById), new { id = seller.SellerId }, sellerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeller(int id, [FromBody] SellerDTO sellerDTO)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id);
            if (seller == null)
            {
                return NotFound($"Vendedor con id {id} no encontrado");
            }

            // Validación de email duplicado
            if (!string.IsNullOrEmpty(sellerDTO.Email))
            {
                var emailExists = await _context.Sellers
                    .AnyAsync(s => s.Email == sellerDTO.Email && s.SellerId != id);
                if (emailExists)
                {
                    return BadRequest($"El email {sellerDTO.Email} ya está registrado");
                }
            }

            seller.FirstName = sellerDTO.FirstName;
            seller.LastName = sellerDTO.LastName;
            seller.Email = sellerDTO.Email;
            seller.PhoneNumber = sellerDTO.PhoneNumber;

            _context.Sellers.Update(seller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            var seller = await _context.Sellers
                .Include(s => s.Sales)
                .FirstOrDefaultAsync(s => s.SellerId == id);

            if (seller == null)
            {
                return NotFound($"Vendedor con id {id} no encontrado");
            }

            // Verificar si tiene ventas asociadas
            if (seller.Sales != null && seller.Sales.Any())
            {
                return BadRequest($"No se puede eliminar el vendedor porque tiene {seller.Sales.Count} venta(s) asociada(s)");
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}