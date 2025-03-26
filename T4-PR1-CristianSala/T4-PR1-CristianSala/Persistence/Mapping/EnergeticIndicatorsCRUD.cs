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
            return await _context.EnergeticIndicators
                .GroupBy(i => i.GetYear())
                .Where(g => g.Key > 0) // Filter out invalid years
                .Select(g => new 
                {
                    Any = g.Key,
                    AverageProdNeta = g.Average(i => i.CDEEBC_ProdNeta)
                })
                .OrderBy(item => item.Any)
                .Cast<dynamic>()
                .ToListAsync();
        }

        /// <summary>
        /// Returns the records with high demand and low production
        /// </summary>
        /// <returns></returns>
        public async Task<List<EnergeticIndicator>> GetRecordsWithHighDemandAndLowProduction()
        {
            return await _context.EnergeticIndicators
                .Where(i => i.CDEEBC_DemandaElectr > 4000 && i.CDEEBC_ProdDisp < 300)
                .ToListAsync();
        }
    }
}
