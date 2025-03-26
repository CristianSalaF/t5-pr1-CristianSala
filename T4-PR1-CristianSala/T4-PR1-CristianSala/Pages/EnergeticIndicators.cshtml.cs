using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T4_PR1_CristianSala.Data;
using T4_PR1_CristianSala.Model;
using T4_PR1_CristianSala.Persistence.Mapping;

namespace T4_PR1_CristianSala.Pages
{
    public class EnergeticIndicatorsModel : PageModel
    {
        private readonly EcoEnergyDbContext _context;
        private readonly EnergeticIndicatorsCRUD _crud;

        public List<EnergeticIndicator> Indicators { get; set; } = [];
        public List<EnergeticIndicator> HighProdNetaRecords { get; set; } = [];
        public List<EnergeticIndicator> HighGasolinaRecords { get; set; } = [];
        public List<dynamic> AverageProdNetaPerYear { get; set; } = [];
        public List<EnergeticIndicator> HighDemandLowProductionRecords { get; set; } = [];

        public EnergeticIndicatorsModel(EcoEnergyDbContext context)
        {
            _context = context;
            _crud = new EnergeticIndicatorsCRUD(context);
        }

        public async Task OnGetAsync()
        {
            Indicators = await _context.EnergeticIndicators.ToListAsync();
            HighProdNetaRecords = await _crud.GetRecordsWithProdNetaGreaterThan3000();
            HighGasolinaRecords = await _crud.GetRecordsWithGasolinaGreaterThan100();
            AverageProdNetaPerYear = await _crud.GetAverageProdNetaPerYear();
            HighDemandLowProductionRecords = await _crud.GetRecordsWithHighDemandAndLowProduction();
        }
    }
}
