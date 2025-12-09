using Microsoft.AspNetCore.Mvc;
using tallermecanico.infretruture.Model ;
using tallermecanico.infretruture.DBContex;
using tallermecanico.aplication.DTOs;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleDetailController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;

        public SaleDetailController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }

        // GET: api/SaleDetail
        [HttpGet]
        public IActionResult GetAllSaleDetails()
        {
            var saleDetails = _aPIContex.SaleDetails.ToList();

            var list = saleDetails.Select(sd => new SaleDetailDTO
            {
                SaleDetailId = sd.SaleDetailId,
                SaleId = sd.SaleId,
                SparePartId = sd.SparePartId,
                Quantity = sd.Quantity,
             
            }).ToList();

            return Ok(list);
        }

        // GET: api/SaleDetail/{id}
        [HttpGet("{id}")]
        public IActionResult GetSaleDetailById(int id)
        {
            var saleDetail = _aPIContex.SaleDetails.FirstOrDefault(sd => sd.SaleDetailId == id);
            if (saleDetail == null)
            {
                return NotFound($"Detalle de venta con id {id} no encontrado");
            }

            var saleDetailDTO = new SaleDetailDTO
            {
                SaleDetailId = saleDetail.SaleDetailId,
                SaleId = saleDetail.SaleId,
                SparePartId = saleDetail.SparePartId,
                Quantity = saleDetail.Quantity,
               
            
            };

            return Ok(saleDetailDTO);
        }

        // POST: api/SaleDetail
        [HttpPost]
        public IActionResult CreateSaleDetail([FromBody] SaleDetailDTO saleDetailDTO)
        {
            var saleDetail = new SaleDetailModel
            {
                SaleId = saleDetailDTO.SaleId,
                SparePartId = saleDetailDTO.SparePartId,
                Quantity = saleDetailDTO.Quantity,
               
            };

            _aPIContex.SaleDetails.Add(saleDetail);
            _aPIContex.SaveChanges();

            return Ok(saleDetailDTO);
        }

        // PUT: api/SaleDetail/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSaleDetail(int id, [FromBody] SaleDetailDTO saleDetailDTO)
        {
            var saleDetail = _aPIContex.SaleDetails.FirstOrDefault(sd => sd.SaleDetailId == id);
            if (saleDetail == null)
            {
                return NotFound($"Detalle de venta con id {id} no encontrado");
            }

            saleDetail.SaleId = saleDetailDTO.SaleId;
            saleDetail.SparePartId = saleDetailDTO.SparePartId;
            saleDetail.Quantity = saleDetailDTO.Quantity;
           

            _aPIContex.SaleDetails.Update(saleDetail);
            _aPIContex.SaveChanges();

            return NoContent();
        }

        // DELETE: api/SaleDetail/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSaleDetail(int id)
        {
            var saleDetail = _aPIContex.SaleDetails.FirstOrDefault(sd => sd.SaleDetailId == id);
            if (saleDetail == null)
            {
                return NotFound($"Detalle de venta con id {id} no encontrado");
            }

            _aPIContex.SaleDetails.Remove(saleDetail);
            _aPIContex.SaveChanges();

            return NoContent();
        }
    }
}
