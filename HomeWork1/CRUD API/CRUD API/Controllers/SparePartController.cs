using Microsoft.AspNetCore.Mvc;
using tallermecanico.domain.Entityes;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Model;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SparePartController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public SparePartController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/SparePart
        [HttpGet]
        public IActionResult GetAllSpareParts()
        {
            var spareParts = _aPIContex.SpareParts.ToList();

            var list = spareParts.Select(s => new SparePartDTO
            {
                SparePartId = s.SparePartId,
                Name = s.Name,
                InitialQuantity = s.InitialQuantity,
                Quantity = s.Quantity,
                UnitPrice = s.UnitPrice,
                WholesalePrice = s.WholesalePrice,
                EntryDate = s.EntryDate
            }).ToList();

            return Ok(list);
        }

        // GET: api/SparePart/{id}
        [HttpGet("{id}")]
        public IActionResult GetSparePartById(int id)
        {
            var sparePart = _aPIContex.SpareParts.FirstOrDefault(s => s.SparePartId == id);
            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            var sparePartDTO = new SparePartDTO
            {
                SparePartId = sparePart.SparePartId,
                Name = sparePart.Name,
                InitialQuantity = sparePart.InitialQuantity,
                Quantity = sparePart.Quantity,
                UnitPrice = sparePart.UnitPrice,
                WholesalePrice = sparePart.WholesalePrice,
                EntryDate = sparePart.EntryDate
            };

            return Ok(sparePartDTO);
        }

        // POST: api/SparePart
        [HttpPost]
        public IActionResult CreateSparePart([FromBody] SparePartDTO sparePartDTO)
        {
            var sparePart = new SparePartModel
            {
                Name = sparePartDTO.Name,
                InitialQuantity = sparePartDTO.Quantity,
                Quantity = sparePartDTO.Quantity,
                UnitPrice = sparePartDTO.UnitPrice,
                WholesalePrice = sparePartDTO.WholesalePrice,
                EntryDate = DateTime.Now
            };

            _aPIContex.SpareParts.Add(sparePart);
            _aPIContex.SaveChanges();

            return Ok(sparePartDTO);
        }

        // PUT: api/SparePart/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSparePart(int id, [FromBody] SparePartDTO sparePartDTO)
        {
            var sparePart = _aPIContex.SpareParts.FirstOrDefault(s => s.SparePartId == id);
            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            sparePart.Name = sparePartDTO.Name;
            sparePart.InitialQuantity = sparePartDTO.InitialQuantity;
            sparePart.Quantity = sparePartDTO.Quantity;
            sparePart.UnitPrice = sparePartDTO.UnitPrice;
            sparePart.WholesalePrice = sparePartDTO.WholesalePrice;
            sparePart.EntryDate = sparePartDTO.EntryDate;

            _aPIContex.SpareParts.Update(sparePart);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/SparePart/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSparePart(int id)
        {
            var sparePart = _aPIContex.SpareParts.FirstOrDefault(s => s.SparePartId == id);
            if (sparePart == null)
            {
                return NotFound($"Repuesto con id {id} no encontrado");
            }

            _aPIContex.SpareParts.Remove(sparePart);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
