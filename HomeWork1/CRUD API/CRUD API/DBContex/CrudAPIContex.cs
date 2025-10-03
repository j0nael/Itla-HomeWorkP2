using CRUD_API.Model.Entyties;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.DBContex
{
    public class CrudAPIContex: DbContext
    {
        public CrudAPIContex(DbContextOptions<CrudAPIContex> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
