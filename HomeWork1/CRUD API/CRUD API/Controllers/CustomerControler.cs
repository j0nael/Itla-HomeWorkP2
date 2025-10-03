using Microsoft.AspNetCore.Mvc;
using CRUD_API.Model.Entyties;
using System.ComponentModel;
using CRUD_API.DBContex;
using CRUD_API.DTO;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;
        public CustomerController(CrudAPIContex aPIContex)
        {
            _aPIContex= aPIContex;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _aPIContex.Customers.ToList();
            var list = new List<CustomerDTO>();

            var seleccustomers = customers.Select(c=> new CustomerDTO
            {
               Id=c.Id,
               FirstName=c.FirstName,
               LastName=c.LastName,
               Email=c.Email,
               PhoneNumber=c.PhoneNumber
               

            }).ToList();
            return Ok(seleccustomers);

        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _aPIContex.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDTO customerdto)
        {
            var customerdb = new Customer
            {

                FirstName = customerdto.FirstName,
                LastName = customerdto.LastName,
                Email = customerdto.Email,
                PhoneNumber = customerdto.PhoneNumber
            };
            
            _aPIContex.Add(customerdto);
           _aPIContex.SaveChanges();
            return Ok(customerdto.Id);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDTO customerdto)
        {
            var customer = _aPIContex.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound($"Cliente no con {id}encontrado");
            }
            customer.FirstName = customerdto.FirstName;
            customer.LastName = customerdto.LastName;
            customer.Email = customerdto.Email;
            customer.PhoneNumber = customerdto.PhoneNumber;
            _aPIContex.Customers.Update(customer);
            _aPIContex.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id ,[FromBody]CustomerDTO customerdto)
        {
            var customer = _aPIContex.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) 
            {
                return NotFound($"Cliente con id:{id} no encontrado");
            }
            _aPIContex.Customers.Remove(customer);
            _aPIContex.SaveChanges();
            return NoContent();
        }

    }
}
