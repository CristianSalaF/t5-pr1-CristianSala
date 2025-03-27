using Microsoft.EntityFrameworkCore;
using T4_PR1_CristianSala.Data;
using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Persistence.Mapping
{
    public class EnergeticIndicatorsCRUD
    {
        private readonly EcoEnergyDbContext _context;

        public EnergeticIndicatorsCRUD(EcoEnergyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns the records with net production greater than 3000
        /// </summary>
        /// <returns></returns>
        public async Task<List<EnergeticIndicator>> GetRecordsWithProdNetaGreaterThan3000()
        {
            return await _context.EnergeticIndicators
                .Where(i => i.CDEEBC_ProdNeta > 3000)
                .OrderBy(i => i.CDEEBC_ProdNeta)
                .ToListAsync();
        }

        /// <summary>
        /// Returns the records with GasolinaAuto greater than 100
        /// </summary>
        /// <returns></returns>
        public async Task<List<EnergeticIndicator>> GetRecordsWithGasolinaGreaterThan100()
        {
            return await _context.EnergeticIndicators
                .Where(i => i.CCAC_GasolinaAuto > 100)
                .OrderByDescending(i => i.CCAC_GasolinaAuto)
                .ToListAsync();
        }

        /// <summary>
        /// Returns the average net production per year
        /// </summary>
        /// <returns></returns>
        public async Task<List<dynamic>> GetAverageProdNetaPerYear()
        {
            var results = new List<dynamic>();
    
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
        
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                SELECT 
                    SUBSTRING(Data, 4, 4) AS Year, 
                    AVG(CDEEBC_ProdNeta) AS AverageProdNeta
                FROM EnergeticIndicators
                WHERE LEN(Data) = 7 AND ISNUMERIC(SUBSTRING(Data, 4, 4)) = 1
                GROUP BY SUBSTRING(Data, 4, 4)
                ORDER BY Year";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(new 
                            { 
                                Year = Convert.ToInt32(reader["Year"]),
                                AverageProdNeta = Convert.ToDouble(reader["AverageProdNeta"])
                            });
                        }
                    }
                }
            }
            return results;
        }



        /// <summary>
        /// Returns the records with high demand and low production
        /// </summary>
        /// <returns></returns>
        public async Task<List<EnergeticIndicator>> GetRecordsWithHighDemandAndLowProduction()
        {
            try
            {
                return await _context.EnergeticIndicators
                    .Where(i => i.CDEEBC_DemandaElectr > 4000 && i.CDEEBC_ProdDisp < 300)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
