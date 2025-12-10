using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CrudAPIContex _context;

        public CustomerController(CrudAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            var list = customers.Select(c => new CustomerDTO
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber
            }).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound($"Cliente con id {id} no encontrado");
            }

            var customerDTO = new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };

            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            // Validación de email duplicado
            if (!string.IsNullOrEmpty(customerDTO.Email))
            {
                var emailExists = await _context.Customers.AnyAsync(c => c.Email == customerDTO.Email);
                if (emailExists)
                {
                    return BadRequest($"El email {customerDTO.Email} ya está registrado");
                }
            }

            var customer = new CustomerModel
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                Email = customerDTO.Email,
                PhoneNumber = customerDTO.PhoneNumber
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            customerDTO.CustomerId = customer.CustomerId;
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDTO customerDTO)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound($"Cliente con id {id} no encontrado");
            }

            // Validación de email duplicado (excluyendo el cliente actual)
            if (!string.IsNullOrEmpty(customerDTO.Email))
            {
                var emailExists = await _context.Customers
                    .AnyAsync(c => c.Email == customerDTO.Email && c.CustomerId != id);
                if (emailExists)
                {
                    return BadRequest($"El email {customerDTO.Email} ya está registrado");
                }
            }

            customer.FirstName = customerDTO.FirstName;
            customer.LastName = customerDTO.LastName;
            customer.Email = customerDTO.Email;
            customer.PhoneNumber = customerDTO.PhoneNumber;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Vehicles)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound($"Cliente con id {id} no encontrado");
            }

            // Verificar si tiene vehículos asociados
            if (customer.Vehicles != null && customer.Vehicles.Any())
            {
                return BadRequest($"No se puede eliminar el cliente porque tiene {customer.Vehicles.Count} vehículo(s) asociado(s)");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}