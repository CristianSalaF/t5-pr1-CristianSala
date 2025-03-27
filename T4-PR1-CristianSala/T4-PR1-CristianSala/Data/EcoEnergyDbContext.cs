using Microsoft.EntityFrameworkCore;
using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Data
{
    public class EcoEnergyDbContext : DbContext
    {
        public EcoEnergyDbContext(DbContextOptions<EcoEnergyDbContext> options) : base(options)
        {
        }
        
        public DbSet<SolarEnergy> SolarEnergies { get; set; }
        public DbSet<WindEnergy> WindEnergies { get; set; }
        public DbSet<HydroEnergy> HydroEnergies { get; set; }

        public DbSet<WaterUsage> WaterUsages { get; set; }
        public DbSet<EnergeticIndicator> EnergeticIndicators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Per Hierarchy(TPH) inheritance pattern 
            // simplifies data and database handling 
            // all derived types are stored in the same table
            modelBuilder.Entity<BaseSimulation>()
                .ToTable("Simulations")
                .HasDiscriminator<string>("Type")
                .HasValue<SolarEnergy>("Sistema Solar")
                .HasValue<WindEnergy>("Sistema Eòlic")
                .HasValue<HydroEnergy>("Sistema Hidroelèctric");

            modelBuilder.Entity<WaterUsage>()
                .ToTable("WaterUsages")
                .HasKey(w => w.ID);
            modelBuilder.Entity<WaterUsage>()
                .Property(w => w.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EnergeticIndicator>()
                .ToTable("EnergeticIndicators")
                .HasKey(e => e.ID);
            modelBuilder.Entity<EnergeticIndicator>()
                .Property(e => e.ID)
                .ValueGeneratedOnAdd();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
