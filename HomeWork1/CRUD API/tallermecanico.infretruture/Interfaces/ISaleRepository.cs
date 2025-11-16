using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.Interfaces
{
    public interface ISaleRepository:IBaseRepository<SaleModel>
    {
        Task CreatesaleAsync(SaleModel sale);
        Task<List<SaleModel>> GetAllsalesAsync();
        Task<SaleModel> GetsaleByIdAsync(int id);
        Task<SaleModel> UpdatesaleAsync(int id, SaleModel sale);
        Task<SaleModel> DeletesaleAsync(int id);
    }
}
