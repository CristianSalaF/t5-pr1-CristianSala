using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using T4_PR1_CristianSala.Data;
using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Service
{
    public class EcoEnergySeedingService
    {
        private const string IndicatorsFilePath = "ModelData/indicadors_energetics_cat.csv";
        private const string WaterUsageFilePath = "ModelData/consum_aigua_cat_per_comarques.csv";
        
        private readonly EcoEnergyDbContext _context;
        private readonly ILogger<EcoEnergySeedingService> _logger;

        public EcoEnergySeedingService(
            EcoEnergyDbContext context,
            ILogger<EcoEnergySeedingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedDatabaseAsync()
        {
            // Check if the database is already seeded
            if (await IsDatabaseSeededAsync())
            {
                _logger.LogInformation("Database is already seeded. Skipping seeding process.");
                return;
            }

            try
            {
                // Seed Water Usages
                await SeedWaterUsagesAsync();

                // Seed Energetic Indicators
                await SeedEnergeticIndicatorsAsync();

                // Save changes
                await _context.SaveChangesAsync();

                _logger.LogInformation("Database seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during database seeding.");
                throw;
            }
        }

        private async Task<bool> IsDatabaseSeededAsync()
        {
            return await _context.WaterUsages.AnyAsync() ||
                   await _context.EnergeticIndicators.AnyAsync();
        }

        private async Task SeedWaterUsagesAsync()
        {
            // Check if WaterUsages are already seeded
            if (await _context.WaterUsages.AnyAsync())
                return;

            string filePath = WaterUsageFilePath;

            if (!File.Exists(filePath))
                throw new FileNotFoundException("WaterUsages.csv file not found", filePath);

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",", // Assuming semicolon-separated CSV
                HasHeaderRecord = true
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, configuration);

            // Register the custom class map
            csv.Context.RegisterClassMap<WaterUsageMap>();

            var waterUsages = csv.GetRecords<WaterUsage>().ToList();
            // Set ID to null to ensure EF Core generates it
            foreach (var waterUsage in waterUsages)
            {
                waterUsage.ID = null;
            }

            await _context.WaterUsages.AddRangeAsync(waterUsages);
        }

        private async Task SeedEnergeticIndicatorsAsync()
        {
            // Check if EnergeticIndicators are already seeded
            if (await _context.EnergeticIndicators.AnyAsync())
                return;

            string filePath = IndicatorsFilePath;

            if (!File.Exists(filePath))
                throw new FileNotFoundException("EnergeticIndicators.csv file not found", filePath);

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",", // Assuming comma-separated CSV
                HasHeaderRecord = true
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, configuration);

            // Register the custom class map
            csv.Context.RegisterClassMap<EnergeticIndicatorMap>();

            var energeticIndicators = csv.GetRecords<EnergeticIndicator>().ToList();
            // Set ID to null to ensure EF Core generates it
            foreach (var indicator in energeticIndicators)
            {
                indicator.ID = null;
            }

            await _context.EnergeticIndicators.AddRangeAsync(energeticIndicators);
        }
    }
}
