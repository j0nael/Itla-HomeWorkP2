using Mapster;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class SaleServices : ISaleServices
    {
        private readonly ISaleRepository _sale;
        private readonly UnitOfWork _unitOfWork;
        public SaleServices(ISaleRepository sale,UnitOfWork unitOfWork)
        {
            _sale = sale;
            _unitOfWork = unitOfWork;
        }


        public async Task<SaleDTO> CreatesaleAsync(SaleDTO SaleDTO)
        {
            var sale = SaleDTO.Adapt<SaleModel>();
            await _sale.CreatesaleAsync(sale);
            return SaleDTO;
        }


        public async Task<List<SaleDTO>> GetAllsalesAsync()
        {
            var sales = await _sale.GetAllsalesAsync();
            return sales.Adapt<List<SaleDTO>>();
        }


        public async Task<SaleDTO> GetsaleByIdAsync(int id)
        {
            var sale = await _sale.GetsaleByIdAsync(id);
            return sale.Adapt<SaleDTO>();
        }


        public async Task<SaleDTO> UpdatesaleAsync(int id, SaleDTO SaleDTO)
        {
            var sale = SaleDTO.Adapt<SaleModel>();
            await _sale.UpdatesaleAsync(id, sale);
            return SaleDTO;
        }


        public async Task DeletesaleAsync(int id)
        {
            await _sale.DeletesaleAsync(id);
        }

        public SaleServices() { }
    }
}
