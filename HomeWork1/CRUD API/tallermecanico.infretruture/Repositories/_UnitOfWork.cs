using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.DBContex;
using tallermecanico.infretruture.Repositories;

namespace tallermecanico.infretruture.Repositories
{
    public class UnitOfWork
    {
     
        public readonly CrudAPIContex _context;
        public CustomerRepositorie Customers { get; }
        public InvoiceRepositorie Invoices { get; } 
        public RepairRepositorie Repairs { get; }

        public SaleRepositorie Sales { get; }

        public SaleDetailsRepositorie SaleDetails { get; }

        public MechanicRepositorie Mechanics { get; }

        public SellerRepositorie Sellers { get; }
        public VehicleRepositorie Vehicles { get; }
        public UnitOfWork(CrudAPIContex context,CustomerRepositorie customerRepositorie,InvoiceRepositorie invoiceRepositorie,
            RepairRepositorie repairRepositorie,SaleRepositorie saleRepositorie,SaleDetailsRepositorie saleDetailsRepositorie,
            MechanicRepositorie mechanicRepositorie,SellerRepositorie sellerRepositorie,VehicleRepositorie vehicleRepositorie)
        {
            _context = context;
            Customers = customerRepositorie;
            Invoices = invoiceRepositorie;
            Repairs = repairRepositorie;
            Sales = saleRepositorie;    
            SaleDetails =  saleDetailsRepositorie;
            Mechanics = mechanicRepositorie;
            Sellers =sellerRepositorie;
            Vehicles = vehicleRepositorie;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
