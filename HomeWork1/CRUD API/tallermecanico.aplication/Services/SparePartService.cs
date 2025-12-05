using Mapster;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class SparePartService : ISparePartService
    {
        private readonly ISparePartRepository _sparePart;
        private readonly UnitOfWork _unitOfWork;
        public SparePartService(ISparePartRepository sparePart,UnitOfWork unitOfWork)
        {
            _sparePart = sparePart;
            _unitOfWork = unitOfWork;
        }

        public async Task<SparePartDTO> CreateSparePartAsync(SparePartDTO sparePartDto)
        {
            var sparePart = sparePartDto.Adapt<SparePartModel>();
            await _sparePart.CreateSparePartAsync(sparePart);
            return sparePartDto;
        }

        public async Task<List<SparePartDTO>> GetAllSparePartsAsync()
        {
            var spareParts = await _sparePart.GetAllSparePartsAsync();
            return spareParts.Adapt<List<SparePartDTO>>();
        }

        public async Task<SparePartDTO> GetSparePartByIdAsync(int id)
        {
            var sparePart = await _sparePart.GetSparePartByIdAsync(id);
            return sparePart.Adapt<SparePartDTO>();
        }

        public async Task<SparePartDTO> UpdateSparePartAsync(int id, SparePartDTO sparePartDto)
        {
            var sparePart = sparePartDto.Adapt<SparePartModel>();
            await _sparePart.UpdateSparePartAsync(id, sparePart);
            return sparePartDto;
        }

        public async Task DeleteSparePartAsync(int id)
        {
            await _sparePart.DeleteSparePartAsync(id);
        }

        public SparePartService() { }
    }
}
