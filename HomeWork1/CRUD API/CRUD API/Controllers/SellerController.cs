using Microsoft.AspNetCore.Mvc;
using tallermecanico.domain.Entityes;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public SellerController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/Seller
        [HttpGet]
        public IActionResult GetAllSellers()
        {
            var sellers = _aPIContex.Sellers.ToList();

            var list = sellers.Select(s => new SellerDTO
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber
            }).ToList();

            return Ok(list);
        }

        // GET: api/Seller/{id}
        [HttpGet("{id}")]
        public IActionResult GetSellerById(int id)
        {
            var seller = _aPIContex.Sellers.FirstOrDefault(s => s.SellerId == id);
            if (seller == null)
                return NotFound($"Vendedor con id {id} no encontrado");

            var sellerDTO = new SellerDTO
            {
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Email = seller.Email,
                PhoneNumber = seller.PhoneNumber
            };

            return Ok(sellerDTO);
        }

        // POST: api/Seller
        [HttpPost]
        public IActionResult CreateSeller([FromBody] SellerDTO sellerDTO)
        {
            var seller = new SellerModel
            {
                FirstName = sellerDTO.FirstName,
                LastName = sellerDTO.LastName,
                Email = sellerDTO.Email,
                PhoneNumber = sellerDTO.PhoneNumber
            };

            _aPIContex.Sellers.Add(seller);
            _aPIContex.SaveChanges();

            return Ok(sellerDTO);
        }

        // PUT: api/Seller/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSeller(int id, [FromBody] SellerDTO sellerDTO)
        {
            var seller = _aPIContex.Sellers.FirstOrDefault(s => s.SellerId == id);
            if (seller == null)
                return NotFound($"Vendedor con id {id} no encontrado");

            seller.FirstName = sellerDTO.FirstName;
            seller.LastName = sellerDTO.LastName;
            seller.Email = sellerDTO.Email;
            seller.PhoneNumber = sellerDTO.PhoneNumber;

            _aPIContex.Sellers.Update(seller);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Seller/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSeller(int id)
        {
            var seller = _aPIContex.Sellers.FirstOrDefault(s => s.SellerId == id);
            if (seller == null)
                return NotFound($"Vendedor con id {id} no encontrado");

            _aPIContex.Sellers.Remove(seller);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
