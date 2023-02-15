using DrugStore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DrugStore.Inftrastructure
{
    public class DrugStoreDbContext : DbContext
    {
        
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<BrandMedicinePrice> BrandMedicinePrice { get; set; }
        public DbSet<PharmacyMedicine> PharmacyMedicine { get; set; }
        public DbSet<AdminAccount> AdminAccount { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PharmacyMedicine>()
                .HasKey(t => new { t.PharmacyId, t.MedicineId });

            modelBuilder.Entity<PharmacyMedicine>()
                .HasOne(pm => pm.Medicine)
                .WithMany(m => m.PharmacyMedicines)
                .HasForeignKey(pm => pm.MedicineId);

            modelBuilder.Entity<PharmacyMedicine>()
                .HasOne(pm => pm.Pharmacy)
                .WithMany(p => p.PharmacyMedicines)
                .HasForeignKey(pm => pm.PharmacyId);

            modelBuilder.Entity<BrandMedicinePrice>()
                .HasKey(t => new { t.BrandId, t.MedicineId });

            modelBuilder.Entity<BrandMedicinePrice>()
                .HasOne(bm => bm.Brand)
                .WithMany(b => b.BrandMedicinePrices)
                .HasForeignKey(bm => bm.BrandId);

            modelBuilder.Entity<BrandMedicinePrice>()
                .HasOne(bm => bm.Medicine)
                .WithMany(m => m.BrandMedicinePrices)
                .HasForeignKey(bm => bm.MedicineId);


        }

        protected readonly IConfiguration Configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
