using tallermecanico.infretruture.Interfaces;
using tallermecanico.aplication.DTOs;
using Mapster;
using tallermecanico.infretruture.Model;
using tallermecanico.aplication.Contract;

namespace tallermecanico.aplication.Services
{
    public class MechanicServices : IMechanicServices
    {
        private readonly IMechanicrepositorie _mechanic;

        public MechanicServices(IMechanicrepositorie mechanic)
        {
            _mechanic = mechanic;
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
