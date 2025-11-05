using tallermecanico.domain.Models.Entityes;
using Microsoft.EntityFrameworkCore;


namespace CRUD_API.DBContex
{
    public class CrudAPIContex: DbContext
    {
        public CrudAPIContex(DbContextOptions<CrudAPIContex> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Sale> sales { get; set; }



    }
}
