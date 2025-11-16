using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.Interfaces
{
    public interface ISellerRepository:IBaseRepository<SellerModel>
    {
        Task CreatesellerAsync(SellerModel seller);
        Task<List<SellerModel>> GetAllsellersAsync();
        Task<SellerModel> GetsellerByIdAsync(int id);
        Task<SellerModel> UpdatesellerAsync(int id, SellerModel seller);
        Task<SellerModel> DeletesellerAsync(int id);
    }
}
