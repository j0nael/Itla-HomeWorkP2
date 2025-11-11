using Microsoft.AspNetCore.Mvc;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;
namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MechanicController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public MechanicController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/Mechanic
        [HttpGet]
        public IActionResult GetAllMechanics()
        {
            var mechanics = _aPIContex.Mechanics.ToList();

            var list = mechanics.Select(m => new MechanicDTO
            {
                MechanicId = m.MechanicId,
                FirstName = m.FirstName,
                Specialty = m.Specialty
            }).ToList();

            return Ok(list);
        }

        // GET: api/Mechanic/{id}
        [HttpGet("{id}")]
        public IActionResult GetMechanicById(int id)
        {
            var mechanic = _aPIContex.Mechanics.FirstOrDefault(m => m.MechanicId == id);
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

        // POST: api/Mechanic
        [HttpPost]
        public IActionResult CreateMechanic([FromBody] MechanicDTO mechanicDTO)
        {
            var mechanico = new MechanicModel
            {
                FirstName = mechanicDTO.FirstName,
                Specialty = mechanicDTO.Specialty
            };

            _aPIContex.Mechanics.Add(mechanico);
            _aPIContex.SaveChanges();

            return Ok(mechanicDTO);
        }

        // PUT: api/Mechanic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMechanic(int id, [FromBody] MechanicDTO mechanicDTO)
        {
            var mechanic = _aPIContex.Mechanics.FirstOrDefault(m => m.MechanicId == id);
            if (mechanic == null)
            {
                return NotFound($"Mecánico con id {id} no encontrado");
            }

            mechanic.FirstName = mechanicDTO.FirstName;
            mechanic.Specialty = mechanicDTO.Specialty;

            _aPIContex.Mechanics.Update(mechanic);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Mechanic/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMechanic(int id)
        {
            var mechanic = _aPIContex.Mechanics.FirstOrDefault(m => m.MechanicId == id);
            if (mechanic == null)
            {
                return NotFound($"Mecánico con id {id} no encontrado");
            }

            _aPIContex.Mechanics.Remove(mechanic);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
