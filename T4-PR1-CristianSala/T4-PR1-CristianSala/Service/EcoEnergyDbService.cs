using T4_PR1_CristianSala.Data;
using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Service
{
    public class EcoEnergyDbService
    {
        private readonly EcoEnergyDbContext _context;

        public EcoEnergyDbService(EcoEnergyDbContext context)
        {
            _context = context;
        }

        public List<BaseSimulation> GetAllSimulations()
        {
            return _context.Set<BaseSimulation>().ToList();
        }

        public List<WaterUsage> GetAllWaterUsages()
        {
            return _context.Set<WaterUsage>().ToList();
        }

        public List<WaterUsage> GetTop10MunicipisWithHighestConsum()
        {
            return _context.WaterUsages.OrderByDescending(w => w.Total).Take(10).ToList();
        }

        public List<dynamic> GetAverageUsageByComarca()
        {
            return _context.WaterUsages.GroupBy(w => w.Comarca)
                .Select(g => new
                {
                    Comarca = g.Key,
                    AverageConsum = g.Average(w => w.ConsumDomesticPerCapita)
                }).ToList<dynamic>();
        }

        public List<WaterUsage> GetSuspiciousUsageValues()
        {
            return _context.WaterUsages.Where(w => w.Total >= 1000000).ToList();
        }

        public List<EnergeticIndicator> GetAllEnergeticIndicators()
        {
            return _context.Set<EnergeticIndicator>().ToList();
        }

        public void SaveSimulation(BaseSimulation simulation)
        {
            switch (simulation)
            {
                case SolarEnergy solarSimulation:
                    _context.SolarEnergies.Add(solarSimulation);
                    break;
                case WindEnergy windSimulation:
                    _context.WindEnergies.Add(windSimulation);
                    break;
                case HydroEnergy hydroSimulation:
                    _context.HydroEnergies.Add(hydroSimulation);
                    break;
                default:
                    throw new ArgumentException("Tipus de simulació desconegut", nameof(simulation));
            }
    
            _context.SaveChanges();
        }

        public void DeleteSimulation(int id, BaseSimulation simulation)
        {
            switch (simulation)
            {
                case SolarEnergy solarSimulation:
                    _context.SolarEnergies.Remove(solarSimulation);
                    break;
                case WindEnergy windSimulation:
                    _context.WindEnergies.Remove(windSimulation);
                    break;
                case HydroEnergy hydroSimulation:
                    _context.HydroEnergies.Remove(hydroSimulation);
                    break;
                default:
                    throw new ArgumentException("Tipus de simulació desconegut", nameof(simulation));
            }
                _context.SaveChanges();
        }

        public void SaveWaterUsage(WaterUsage waterUsage)
        {
            _context.WaterUsages.Add(waterUsage);
            _context.SaveChanges();
        }

        public void DeleteWaterUsage(int id)
        {
            var waterUsage = _context.Set<WaterUsage>().Find(id);
            if (waterUsage != null)
            {
                _context.WaterUsages.Remove(waterUsage);
                _context.SaveChanges();
            }
        }

        public void SaveEnergeticIndicator(EnergeticIndicator energeticIndicator)
        {
            _context.EnergeticIndicators.Add(energeticIndicator);
            _context.SaveChanges();
        }

        public void DeleteEnergeticIndicator(int id)
        {
            var energeticIndicator = _context.Set<EnergeticIndicator>().Find(id);
            if (energeticIndicator != null)
            {
                _context.EnergeticIndicators.Remove(energeticIndicator);
                _context.SaveChanges();
            }
        }
    }
}
