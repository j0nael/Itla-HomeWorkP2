using Microsoft.EntityFrameworkCore;
using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.DBContex
{


   
    
        public class CrudAPIContex : DbContext
        {
            public CrudAPIContex(DbContextOptions<CrudAPIContex> options)
                : base(options)
            {
            }

            // DbSets
            public DbSet<CustomerModel> Customers { get; set; }
            public DbSet<VehicleModel> Vehicles { get; set; }
            public DbSet<MechanicModel> Mechanics { get; set; }
            public DbSet<RepairModel> Repairs { get; set; }
            public DbSet<SellerModel> Sellers { get; set; }
            public DbSet<SparePartModel> SpareParts { get; set; }
            public DbSet<SaleModel> Sales { get; set; }
            public DbSet<SaleDetailModel> SaleDetails { get; set; }
            public DbSet<InvoiceModel> Invoices { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // ==================== CUSTOMER ====================
                modelBuilder.Entity<CustomerModel>(entity =>
                {
                    entity.ToTable("Customers");
                    entity.HasKey(e => e.Id);

                    entity.Property(e => e.Id).HasColumnName("CustomerId");
                    entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.Email).HasMaxLength(150);
                    entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);

                    // Índice en Email
                    entity.HasIndex(e => e.Email);
                });

                // ==================== VEHICLE ====================
                modelBuilder.Entity<VehicleModel>(entity =>
                {
                    entity.ToTable("Vehicles");
                    entity.HasKey(e => e.VehicleId);

                    entity.Property(e => e.LicensePlate).IsRequired().HasMaxLength(20);
                    entity.Property(e => e.Brand).IsRequired().HasMaxLength(50);
                    entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                    entity.Property(e => e.Color).HasMaxLength(30);

                    // Índice único para placa
                    entity.HasIndex(e => e.LicensePlate).IsUnique();

                    // FK: Vehicle -> Customer (RESTRICT para evitar cascade paths)
                    entity.HasOne(e => e.Customer)
                        .WithMany(c => c.Vehicles)
                        .HasForeignKey(e => e.CustomerId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // ==================== MECHANIC ====================
                modelBuilder.Entity<MechanicModel>(entity =>
                {
                    entity.ToTable("Mechanics");
                    entity.HasKey(e => e.MechanicId);

                    entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.Specialty).IsRequired().HasMaxLength(100);
                });

                // ==================== REPAIR ====================
                modelBuilder.Entity<RepairModel>(entity =>
                {
                    entity.ToTable("Repairs");
                    entity.HasKey(e => e.RepairId);

                    entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                    entity.Property(e => e.Cost).HasColumnType("decimal(18,2)").IsRequired();
                    entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()");

                    // FK: Repair -> Vehicle (RESTRICT - evita cascade conflict)
                    entity.HasOne(e => e.Vehicle)
                        .WithMany(v => v.Repairs)
                        .HasForeignKey(e => e.VehicleId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // FK: Repair -> Mechanic (RESTRICT)
                    entity.HasOne(e => e.Mechanic)
                        .WithMany(m => m.Repairs)
                        .HasForeignKey(e => e.MechanicId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // FK: Repair -> Invoice (SET NULL cuando se elimina factura)
                    entity.HasOne(e => e.Invoice)
                        .WithMany(i => i.Repairs)
                        .HasForeignKey(e => e.InvoiceId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired(false);

                    // Índice en fecha
                    entity.HasIndex(e => e.Date);

                    // Índice compuesto para búsquedas
                    entity.HasIndex(e => new { e.VehicleId, e.Date });
                });

                // ==================== SELLER ====================
                modelBuilder.Entity<SellerModel>(entity =>
                {
                    entity.ToTable("Sellers");
                    entity.HasKey(e => e.SellerId);

                    entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.Email).HasMaxLength(150);
                    entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                });

                // ==================== SPARE PART ====================
                modelBuilder.Entity<SparePartModel>(entity =>
                {
                    entity.ToTable("SpareParts");
                    entity.HasKey(e => e.SparePartId);

                    entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                    entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
                    entity.Property(e => e.WholesalePrice).HasColumnType("decimal(18,2)").IsRequired();
                    entity.Property(e => e.EntryDate).HasDefaultValueSql("GETDATE()");
                });

                // ==================== SALE ====================
                modelBuilder.Entity<SaleModel>(entity =>
                {
                    entity.ToTable("Sales");
                    entity.HasKey(e => e.SaleId);

                    entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                    entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()");

                    // FK: Sale -> Customer (RESTRICT)
                    entity.HasOne(e => e.Customer)
                        .WithMany(c => c.Sales)
                        .HasForeignKey(e => e.CustomerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // FK: Sale -> Seller (RESTRICT)
                    entity.HasOne(e => e.Seller)
                        .WithMany(s => s.Sales)
                        .HasForeignKey(e => e.SellerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // FK: Sale -> Invoice (SET NULL)
                    entity.HasOne(e => e.Invoice)
                        .WithMany(i => i.Sales)
                        .HasForeignKey(e => e.InvoiceId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired(false);

                    // Índice en fecha
                    entity.HasIndex(e => e.Date);
                });

                // ==================== SALE DETAIL ====================
                modelBuilder.Entity<SaleDetailModel>(entity =>
                {
                    entity.ToTable("SaleDetails");
                    entity.HasKey(e => e.SaleDetailId);

                    entity.Property(e => e.Quantity).IsRequired();
                    entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();

                    // FK: SaleDetail -> Sale (CASCADE - si se elimina venta, se eliminan detalles)
                    entity.HasOne(e => e.Sale)
                        .WithMany(s => s.SaleDetails)
                        .HasForeignKey(e => e.SaleId)
                        .OnDelete(DeleteBehavior.Cascade);

                    // FK: SaleDetail -> SparePart (RESTRICT - no permitir eliminar piezas en uso)
                    entity.HasOne(e => e.SparePart)
                        .WithMany(sp => sp.SaleDetails)
                        .HasForeignKey(e => e.SparePartId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // Ignorar propiedad calculada
                    entity.Ignore(e => e.Subtotal);
                });

                // ==================== INVOICE ====================
                modelBuilder.Entity<InvoiceModel>(entity =>
                {
                    entity.ToTable("Invoices");
                    entity.HasKey(e => e.InvoiceId);

                    entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                    entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()");

                    // FK: Invoice -> Customer (RESTRICT)
                    entity.HasOne(e => e.Customer)
                        .WithMany(c => c.Invoices)
                        .HasForeignKey(e => e.CustomerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // FK: Invoice -> Seller (RESTRICT)
                    entity.HasOne(e => e.Seller)
                        .WithMany(s => s.Invoices)
                        .HasForeignKey(e => e.SellerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    // Índice en fecha
                    entity.HasIndex(e => e.Date);
                });
            }
        }
    }
