using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MechanicController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public MechanicController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMechanics()
        {
            var mechanics = await _context.Mechanics.ToListAsync();
            var list = mechanics.Select(m => new MechanicDTO
            {
                MechanicId = m.MechanicId,
                FirstName = m.FirstName,
                Specialty = m.Specialty
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMechanicById(int id)
        {
            var mechanic = await _context.Mechanics.FirstOrDefaultAsync(m => m.MechanicId == id);
            if (mechanic == null)
            {
                return NotFound($"Mecánico con id {id} no encontrado");
            }

            var mechanicDTO = new MechanicDTO
            {
                MechanicId = mechanic.MechanicId,
                FirstName = mechanic.FirstName,
                Specialty = mechanic.Specialty
            };

            return Ok(mechanicDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMechanic([FromBody] MechanicDTO mechanicDTO)
        {
            if (string.IsNullOrWhiteSpace(mechanicDTO.FirstName))
            {
                return BadRequest("El nombre es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(mechanicDTO.Specialty))
            {
                return BadRequest("La especialidad es obligatoria");
            }

            var mechanic = new MechanicModel
            {
                FirstName = mechanicDTO.FirstName,
                Specialty = mechanicDTO.Specialty
            };

            _context.Mechanics.Add(mechanic);
            await _context.SaveChangesAsync();

            mechanicDTO.MechanicId = mechanic.MechanicId;
            return CreatedAtAction(nameof(GetMechanicById), new { id = mechanic.MechanicId }, mechanicDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMechanic(int id, [FromBody] MechanicDTO mechanicDTO)
        {
            var mechanic = await _context.Mechanics.FirstOrDefaultAsync(m => m.MechanicId == id);
            if (mechanic == null)
            {
                return NotFound($"Mecánico con id {id} no encontrado");
            }

            mechanic.FirstName = mechanicDTO.FirstName;
            mechanic.Specialty = mechanicDTO.Specialty;

            _context.Mechanics.Update(mechanic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMechanic(int id)
        {
            var mechanic = await _context.Mechanics
                .Include(m => m.Repairs)
                .FirstOrDefaultAsync(m => m.MechanicId == id);

            if (mechanic == null)
            {
                return NotFound($"Mecánico con id {id} no encontrado");
            }

            // Verificar si tiene reparaciones
            if (mechanic.Repairs != null && mechanic.Repairs.Any())
            {
                return BadRequest($"No se puede eliminar el mecánico porque tiene {mechanic.Repairs.Count} reparación(es) asociada(s)");
            }

            _context.Mechanics.Remove(mechanic);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}