using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class SellerServices : ISellerServices
    {
        private readonly ISellerRepository _seller;
        private readonly UnitOfWork _unitOfWork;

        public SellerServices(ISellerRepository seller,UnitOfWork unitOfWork)
        {
            _seller = seller;
            _unitOfWork = unitOfWork;
        }


        public async Task<SellerDTO> CreatesellerAsync(SellerDTO SellerDTO)
        {
            var seller = SellerDTO.Adapt<SellerModel>();
            await _seller.CreatesellerAsync(seller);
            return SellerDTO;
        }


        public async Task<List<SellerDTO>> GetAllsellersAsync()
        {
            var sellers = await _seller.GetAllsellersAsync();
            return sellers.Adapt<List<SellerDTO>>();
        }


        public async Task<SellerDTO> GetsellerByIdAsync(int id)
        {
            var seller = await _seller.GetsellerByIdAsync(id);
            return seller.Adapt<SellerDTO>();
        }


        public async Task<SellerDTO> UpdatesellerAsync(int id, SellerDTO SellerDTO)
        {
            var seller = SellerDTO.Adapt<SellerModel>();
            await _seller.UpdatesellerAsync(id, seller);
            return SellerDTO;
        }


        public async Task DeletesellerAsync(int id)
        {
            await _seller.DeletesellerAsync(id);
        }

        public SellerServices() { }
    }
}
