using Microsoft.AspNetCore.Mvc;
using tallermecanico.domain.Entityes;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public VehicleController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/Vehicle
        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            var vehicles = _aPIContex.Vehicles.ToList();

            var list = vehicles.Select(v => new VehicleDTO

            {   VehicleId=v.VehicleId,
                LicensePlate = v.LicensePlate,
                Brand = v.Brand,
                Model = v.Model,
                Color = v.Color,
                Year = v.Year,
                CustomerId = v.CustomerId,
              
            }).ToList();

            return Ok(list);
        }

        // GET: api/Vehicle/{id}
        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = _aPIContex.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (vehicle == null)
                return NotFound($"Vehículo con id {id} no encontrado");

            var vehicleDTO = new VehicleDTO
            {
                VehicleId=vehicle.VehicleId,
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Color = vehicle.Color,
                Year = vehicle.Year,
                CustomerId = vehicle.CustomerId,
                
            };

            return Ok(vehicleDTO);
        }

        // POST: api/Vehicle
        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleDTO vehicleDTO)
        {
            var customerExists = _aPIContex.Customers.Any(c => c.Id == vehicleDTO.CustomerId);
            if (!customerExists)
                return BadRequest($"El CustomerId {vehicleDTO.CustomerId} no existe.");

            if (vehicleDTO.SellerId.HasValue)
            {
                var sellerExists = _aPIContex.Sellers.Any(s => s.SellerId == vehicleDTO.SellerId.Value);
                if (!sellerExists)
                    return BadRequest($"El SellerId {vehicleDTO.SellerId.Value} no existe.");
            }

            var vehicle = new VehicleModel
            {
                VehicleId=vehicleDTO.VehicleId,
                LicensePlate = vehicleDTO.LicensePlate,
                Brand = vehicleDTO.Brand,
                Model = vehicleDTO.Model,
                Color = vehicleDTO.Color,
                Year = vehicleDTO.Year,
                CustomerId = vehicleDTO.CustomerId,
               
            };

            _aPIContex.Vehicles.Add(vehicle);
            _aPIContex.SaveChanges();

            return Ok(vehicleDTO);
        }

        // PUT: api/Vehicle/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            var vehicle = _aPIContex.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (vehicle == null)
                return NotFound($"Vehículo con id {id} no encontrado");

            var customerExists = _aPIContex.Customers.Any(c => c.Id == vehicleDTO.CustomerId);
            if (!customerExists)
                return BadRequest($"El CustomerId {vehicleDTO.CustomerId} no existe.");

            if (vehicleDTO.SellerId.HasValue)
            {
                var sellerExists = _aPIContex.Sellers.Any(s => s.SellerId == vehicleDTO.SellerId.Value);
                if (!sellerExists)
                    return BadRequest($"El SellerId {vehicleDTO.SellerId.Value} no existe.");
            }
            vehicle.VehicleId = vehicleDTO.VehicleId;
            vehicle.LicensePlate = vehicleDTO.LicensePlate;
            vehicle.Brand = vehicleDTO.Brand;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Color = vehicleDTO.Color;
            vehicle.Year = vehicleDTO.Year;
            vehicle.CustomerId = vehicleDTO.CustomerId;
          

            _aPIContex.Vehicles.Update(vehicle);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Vehicle/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = _aPIContex.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (vehicle == null)
                return NotFound($"Vehículo con id {id} no encontrado");

            _aPIContex.Vehicles.Remove(vehicle);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
