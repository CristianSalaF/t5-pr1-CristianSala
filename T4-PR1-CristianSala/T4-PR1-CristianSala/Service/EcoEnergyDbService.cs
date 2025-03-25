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
    }
}
