using Mapster;
using tallermecanico.aplication.Contract;
using tallermecanico.aplication.DTOs;
using tallermecanico.infretruture.Interfaces;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.aplication.Services
{
    public class MechanicServices : IMechanicServices
    {
        private readonly IMechanicrepositorie _mechanic;
        private readonly UnitOfWork _unitOfWork;
        public MechanicServices(IMechanicrepositorie mechanic,UnitOfWork unitOfWork)
        {
            _mechanic = mechanic;
            _unitOfWork = unitOfWork;
        }


        public async Task<MechanicDTO> CreatemechanicAsync(MechanicDTO MechanicDTO)
        {
            var mechanic = MechanicDTO.Adapt<MechanicModel>();
            await _mechanic.CreatemechanicAsync(mechanic);
            return MechanicDTO;
        }


        public async Task<List<MechanicDTO>> GetAllmechanicsAsync()
        {
            var mechanics = await _mechanic.GetAllmechanicsAsync();
            return mechanics.Adapt<List<MechanicDTO>>();
        }


        public async Task<MechanicDTO> GetmechanicByIdAsync(int id)
        {
            var mechanic = await _mechanic.GetmechanicByIdAsync(id);
            return mechanic.Adapt<MechanicDTO>();
        }


        public async Task<MechanicDTO> UpdatemechanicAsync(int id, MechanicDTO MechanicDTO)
        {
            var mechanic = MechanicDTO.Adapt<MechanicModel>();
            await _mechanic.UpdatemechanicAsync(id, mechanic);
            return MechanicDTO;
        }


        public async Task DeletemechanicAsync(int id)
        {
            await _mechanic.DeletemechanicAsync(id);
        }

        public MechanicServices() { }
    }
}
