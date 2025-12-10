using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public VehicleController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _context.Vehicles
                .Include(v => v.Customer)
                .ToListAsync();

            var list = vehicles.Select(v => new VehicleDTO
            {
                VehicleId = v.VehicleId,
                LicensePlate = v.LicensePlate,
                Brand = v.Brand,
                Model = v.Model,
                Color = v.Color,
                Year = v.Year,
                CustomerId = v.CustomerId,
                CustomerName = $"{v.Customer.FirstName} {v.Customer.LastName}"
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.Customer)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound($"Vehículo con id {id} no encontrado");
            }

            var vehicleDTO = new VehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Color = vehicle.Color,
                Year = vehicle.Year,
                CustomerId = vehicle.CustomerId,
                CustomerName = $"{vehicle.Customer.FirstName} {vehicle.Customer.LastName}"
            };

            return Ok(vehicleDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDTO vehicleDTO)
        {
            // Validar que el cliente exista
            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == vehicleDTO.CustomerId);
            if (!customerExists)
            {
                return BadRequest($"El cliente con ID {vehicleDTO.CustomerId} no existe");
            }

            // Validar placa duplicada
            var plateExists = await _context.Vehicles.AnyAsync(v => v.LicensePlate == vehicleDTO.LicensePlate);
            if (plateExists)
            {
                return BadRequest($"La placa {vehicleDTO.LicensePlate} ya está registrada");
            }

            var vehicle = new VehicleModel
            {
                LicensePlate = vehicleDTO.LicensePlate,
                Brand = vehicleDTO.Brand,
                Model = vehicleDTO.Model,
                Color = vehicleDTO.Color,
                Year = vehicleDTO.Year,
                CustomerId = vehicleDTO.CustomerId
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            vehicleDTO.VehicleId = vehicle.VehicleId;
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.VehicleId }, vehicleDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound($"Vehículo con id {id} no encontrado");
            }

            // Validar que el cliente exista
            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == vehicleDTO.CustomerId);
            if (!customerExists)
            {
                return BadRequest($"El cliente con ID {vehicleDTO.CustomerId} no existe");
            }

            // Validar placa duplicada (excluyendo el vehículo actual)
            var plateExists = await _context.Vehicles
                .AnyAsync(v => v.LicensePlate == vehicleDTO.LicensePlate && v.VehicleId != id);
            if (plateExists)
            {
                return BadRequest($"La placa {vehicleDTO.LicensePlate} ya está registrada");
            }

            vehicle.LicensePlate = vehicleDTO.LicensePlate;
            vehicle.Brand = vehicleDTO.Brand;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Color = vehicleDTO.Color;
            vehicle.Year = vehicleDTO.Year;
            vehicle.CustomerId = vehicleDTO.CustomerId;

            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.Repairs)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound($"Vehículo con id {id} no encontrado");
            }

            // Verificar si tiene reparaciones
            if (vehicle.Repairs != null && vehicle.Repairs.Any())
            {
                return BadRequest($"No se puede eliminar el vehículo porque tiene {vehicle.Repairs.Count} reparación(es) asociada(s)");
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}