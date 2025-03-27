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

        /// <summary>
        /// Dependency injection for the DbContext and the logger.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public EcoEnergySeedingService(
            EcoEnergyDbContext context,
            ILogger<EcoEnergySeedingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Seeds the database asynchronously, after checking if it was already seeded, then logs it.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if the database has already been seeded and then returns the Task of type bool.
        /// Since the process is asynchronous, it waits for other taks to finish before doing so.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsDatabaseSeededAsync()
        {
            return await _context.WaterUsages.AnyAsync() ||
                   await _context.EnergeticIndicators.AnyAsync();
        }

        /// <summary>
        /// Seeding method for the WaterUsages entity:
        /// -Handles the files
        /// -Registers the custom class map
        /// -Sets "Id" to null values so EF Core autogenerates them
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
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
                Delimiter = ",",
                HasHeaderRecord = true
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, configuration);

            // Register the custom class map
            csv.Context.RegisterClassMap<WaterUsageMap>();

            var waterUsages = csv.GetRecords<WaterUsage>().ToList();

            await _context.WaterUsages.AddRangeAsync(waterUsages);
        }

        /// <summary>
        /// Seeding method for the WaterUsages entity:
        /// -Handles the files
        /// -Registers the custom class map
        /// -Sets "Id" to null values so EF Core autogenerates them
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        private async Task SeedEnergeticIndicatorsAsync()
        {
            // Checks if EnergeticIndicators are already seeded
            if (await _context.EnergeticIndicators.AnyAsync())
                return;

            string filePath = IndicatorsFilePath;

            if (!File.Exists(filePath))
                throw new FileNotFoundException("EnergeticIndicators.csv file not found", filePath);

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, configuration);

            // Register the custom class map
            csv.Context.RegisterClassMap<EnergeticIndicatorMap>();

            var energeticIndicators = csv.GetRecords<EnergeticIndicator>().ToList();

            await _context.EnergeticIndicators.AddRangeAsync(energeticIndicators);
        }
    }
}
