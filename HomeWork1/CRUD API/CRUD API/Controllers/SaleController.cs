using Microsoft.AspNetCore.Mvc;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.DBContex;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public SaleController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/Sale
        [HttpGet]
        public IActionResult GetAllSales()
        {
            var sales = _aPIContex.Sales.ToList();

            var list = sales.Select(s => new SaleDTO
            {
                CustomerId = s.CustomerId,
                SellerId = s.SellerId,
               
                Date = s.Date
            }).ToList();

            return Ok(list);
        }

        // GET: api/Sale/{id}
        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            var sale = _aPIContex.Sales.FirstOrDefault(s => s.SaleId == id);
            if (sale == null)
                return NotFound($"Venta con id {id} no encontrada");

            var saleDTO = new SaleDTO
            {
                CustomerId = sale.CustomerId,
                SellerId = sale.SellerId,
               
                Date = sale.Date
            };

            return Ok(saleDTO);
        }

        // POST: api/Sale
        [HttpPost]
        public IActionResult CreateSale([FromBody] SaleDTO saleDTO)
        {
            var customerExists = _aPIContex.Customers.Any(c => c.Id == saleDTO.CustomerId);
            if (!customerExists)
                return BadRequest($"El CustomerId {saleDTO.CustomerId} no existe.");

            var sellerExists = _aPIContex.Sellers.Any(s => s.SellerId == saleDTO.SellerId);
            if (!sellerExists)
                return BadRequest($"El SellerId {saleDTO.SellerId} no existe.");

            var sale = new SaleModel
            {
                CustomerId = saleDTO.CustomerId,
                SellerId = saleDTO.SellerId,
                
                Date = saleDTO.Date
            };

            _aPIContex.Sales.Add(sale);
            _aPIContex.SaveChanges();

            return Ok(saleDTO);
        }

        // PUT: api/Sale/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] SaleDTO saleDTO)
        {
            var sale = _aPIContex.Sales.FirstOrDefault(s => s.SaleId == id);
            if (sale == null)
                return NotFound($"Venta con id {id} no encontrada");

            var customerExists = _aPIContex.Customers.Any(c => c.Id == saleDTO.CustomerId);
            if (!customerExists)
                return BadRequest($"El CustomerId {saleDTO.CustomerId} no existe.");

            var sellerExists = _aPIContex.Sellers.Any(s => s.SellerId == saleDTO.SellerId);
            if (!sellerExists)
                return BadRequest($"El SellerId {saleDTO.SellerId} no existe.");

            sale.CustomerId = saleDTO.CustomerId;
            sale.SellerId = saleDTO.SellerId;
            
            sale.Date = saleDTO.Date;

            _aPIContex.Sales.Update(sale);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Sale/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = _aPIContex.Sales.FirstOrDefault(s => s.SaleId == id);
            if (sale == null)
                return NotFound($"Venta con id {id} no encontrada");

            _aPIContex.Sales.Remove(sale);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
