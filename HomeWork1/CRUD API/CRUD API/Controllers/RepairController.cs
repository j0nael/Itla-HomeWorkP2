using Microsoft.AspNetCore.Mvc;
using tallermecanico.domain.Entityes;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public RepairController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/Repair
        [HttpGet]
        public IActionResult GetAllRepairs()
        {
            var repairs = _aPIContex.Repairs.ToList();

            var list = repairs.Select(r => new RepairDTO
            {
                RepairId = r.RepairId,
                VehicleId = r.VehicleId,
                MechanicId = r.MechanicId,
                InvoiceId = r.InvoiceId,
                Description = r.Description,
                Date = r.Date
            }).ToList();

            return Ok(list);
        }

        // GET: api/Repair/{id}
        [HttpGet("{id}")]
        public IActionResult GetRepairById(int id)
        {
            var repair = _aPIContex.Repairs.FirstOrDefault(r => r.RepairId == id);
            if (repair == null)
            {
                return NotFound($"Reparación con id {id} no encontrada");
            }

            var repairDTO = new RepairDTO
            {
                RepairId = repair.RepairId,
                VehicleId = repair.VehicleId,
                
                MechanicId = repair.MechanicId,
                
                InvoiceId = repair.InvoiceId,
                Description = repair.Description,
                
                Date = repair.Date
            };

            return Ok(repairDTO);
        }

        // POST: api/Repair
        [HttpPost]
        public IActionResult CreateRepair([FromBody] RepairDTO repairDTO)
        {
            var repair = new RepairModel
            {
               
                
                MechanicId = repairDTO.MechanicId,
                InvoiceId = repairDTO.InvoiceId,
                Description = repairDTO.Description,
                Date = DateTime.Now
            };

            _aPIContex.Repairs.Add(repair);
            _aPIContex.SaveChanges();

            return Ok(repairDTO);
        }

        // PUT: api/Repair/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateRepair(int id, [FromBody] RepairDTO repairDTO)
        {
            var repair = _aPIContex.Repairs.FirstOrDefault(r => r.RepairId == id);
            if (repair == null)
            {
                return NotFound($"Reparación con id {id} no encontrada");
            }

            
           
            repair.MechanicId = repairDTO.MechanicId;
            
            repair.InvoiceId = repairDTO.InvoiceId;
            repair.Description = repairDTO.Description;
           
            repair.Date = repairDTO.Date;

            _aPIContex.Repairs.Update(repair);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Repair/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRepair(int id)
        {
            var repair = _aPIContex.Repairs.FirstOrDefault(r => r.RepairId == id);
            if (repair == null)
            {
                return NotFound($"Reparación con id {id} no encontrada");
            }

            _aPIContex.Repairs.Remove(repair);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
