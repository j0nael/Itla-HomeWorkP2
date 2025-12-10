using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public RepairController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRepairs()
        {
            var repairs = await _context.Repairs
                .Include(r => r.Mechanic)
                .Include(r => r.Vehicle)
                    .ThenInclude(v => v.Customer)
                .ToListAsync();

            var list = repairs.Select(r => new RepairDTO
            {
                RepairId = r.RepairId,
                VehicleId = r.VehicleId,
                LicensePlate = r.Vehicle.LicensePlate,
                MechanicId = r.MechanicId,
                MechanicName = r.Mechanic.FirstName,
                CustomerId = r.Vehicle.CustomerId,
                CustomerName = $"{r.Vehicle.Customer.FirstName} {r.Vehicle.Customer.LastName}",
                InvoiceId = r.InvoiceId,
                Description = r.Description,
                Cost = (double)r.Cost,
                Date = r.Date
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepairById(int id)
        {
            var repair = await _context.Repairs
                .Include(r => r.Mechanic)
                .Include(r => r.Vehicle)
                    .ThenInclude(v => v.Customer)
                .FirstOrDefaultAsync(r => r.RepairId == id);

            if (repair == null)
            {
                return NotFound($"Reparación con id {id} no encontrada");
            }

            var repairDTO = new RepairDTO
            {
                RepairId = repair.RepairId,
                VehicleId = repair.VehicleId,
                LicensePlate = repair.Vehicle.LicensePlate,
                MechanicId = repair.MechanicId,
                MechanicName = repair.Mechanic.FirstName,
                CustomerId = repair.Vehicle.CustomerId,
                CustomerName = $"{repair.Vehicle.Customer.FirstName} {repair.Vehicle.Customer.LastName}",
                InvoiceId = repair.InvoiceId,
                Description = repair.Description,
                Cost = (double)repair.Cost,
                Date = repair.Date
            };

            return Ok(repairDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRepair([FromBody] RepairDTO repairDTO)
        {
            // Validar que el vehículo exista
            var vehicleExists = await _context.Vehicles.AnyAsync(v => v.VehicleId == repairDTO.VehicleId);
            if (!vehicleExists)
            {
                return BadRequest($"El vehículo con ID {repairDTO.VehicleId} no existe");
            }

            // Validar que el mecánico exista
            var mechanicExists = await _context.Mechanics.AnyAsync(m => m.MechanicId == repairDTO.MechanicId);
            if (!mechanicExists)
            {
                return BadRequest($"El mecánico con ID {repairDTO.MechanicId} no existe");
            }

            //// Validar que la factura exista (si se proporciona)
            //if (repairDTO.InvoiceId.HasValue)
            //{
            //    var invoiceExists = await _context.Invoices.AnyAsync(i => i.InvoiceId == repairDTO.InvoiceId.Value);
            //    if (!invoiceExists)
            //    {
            //        return BadRequest($"La factura con ID {repairDTO.InvoiceId} no existe");
            //    }
            //}

            if (repairDTO.InvoiceId == 0)
                repairDTO.InvoiceId = null;


            var repair = new RepairModel
            {
                VehicleId = repairDTO.VehicleId,
                MechanicId = repairDTO.MechanicId,
                InvoiceId = repairDTO.InvoiceId,
                Description = repairDTO.Description,
                Cost = (decimal)repairDTO.Cost,
                Date = DateTime.Now
            };

            _context.Repairs.Add(repair);
            await _context.SaveChangesAsync();

            repairDTO.RepairId = repair.RepairId;
            return CreatedAtAction(nameof(GetRepairById), new { id = repair.RepairId }, repairDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepair(int id, [FromBody] RepairDTO repairDTO)
        {
            var repair = await _context.Repairs.FirstOrDefaultAsync(r => r.RepairId == id);
            if (repair == null)
            {
                return NotFound($"Reparación con id {id} no encontrada");
            }

            // Validar que el vehículo exista
            var vehicleExists = await _context.Vehicles.AnyAsync(v => v.VehicleId == repairDTO.VehicleId);
            if (!vehicleExists)
            {
                return BadRequest($"El vehículo con ID {repairDTO.VehicleId} no existe");
            }

            // Validar que el mecánico exista
            var mechanicExists = await _context.Mechanics.AnyAsync(m => m.MechanicId == repairDTO.MechanicId);
            if (!mechanicExists)
            {
                return BadRequest($"El mecánico con ID {repairDTO.MechanicId} no existe");
            }

            repair.VehicleId = repairDTO.VehicleId;
            repair.MechanicId = repairDTO.MechanicId;
            repair.InvoiceId = repairDTO.InvoiceId;
            repair.Description = repairDTO.Description;
            repair.Cost = (decimal)repairDTO.Cost;

            _context.Repairs.Update(repair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            var repair = await _context.Repairs.FirstOrDefaultAsync(r => r.RepairId == id);
            if (repair == null)
            {
                return NotFound($"Reparación con id {id} no encontrada");
            }

            _context.Repairs.Remove(repair);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}