using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.Model;
namespace tallermecanico.infretruture.DBContex
{
    public class CrudAPIContex: DbContext
    {
        public CrudAPIContex(DbContextOptions<CrudAPIContex> options) : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<MechanicModel> Mechanics { get; set; }
        public DbSet<SellerModel> Sellers { get; set; }
        public DbSet<SparePartModel> SpareParts { get; set; }
        public DbSet<RepairModel> Repairs { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<SaleModel> Sales { get; set; }

        public DbSet<SaleDetailModel> SaleDetails { get; set; }





    }
}
