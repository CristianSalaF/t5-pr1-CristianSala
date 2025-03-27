using T4_PR1_CristianSala.Data;
using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Service
{
    public partial class EcoEnergyDbService
    {
        private readonly EcoEnergyDbContext _context;

        public EcoEnergyDbService(EcoEnergyDbContext context)
        {
            _context = context;
        }
    }
}
