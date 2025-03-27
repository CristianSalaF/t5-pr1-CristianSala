using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1_CristianSala.Model;
using T4_PR1_CristianSala.Service;

namespace T4_PR1_CristianSala.Pages
{
    public class EnergeticIndicatorsModel : PageModel
    {
        private readonly EcoEnergyDbService _ecoEnergyDbService;

        public List<EnergeticIndicator> Indicators { get; set; }
        public List<EnergeticIndicator> HighProdNetaRecords { get; set; }
        public List<EnergeticIndicator> HighGasolinaRecords { get; set; }
        public List<dynamic> AverageProdNetaPerYear { get; set; }
        public List<EnergeticIndicator> HighDemandLowProductionRecords { get; set; }

        public EnergeticIndicatorsModel(EcoEnergyDbService ecoEnergyDbService)
        {
            _ecoEnergyDbService = ecoEnergyDbService;
            Indicators = new List<EnergeticIndicator>();
            HighProdNetaRecords = new List<EnergeticIndicator>();
            HighGasolinaRecords = new List<EnergeticIndicator>();
            AverageProdNetaPerYear = new List<dynamic>();
            HighDemandLowProductionRecords = new List<EnergeticIndicator>();
        }

        public void OnGet()
        {
            Indicators = _ecoEnergyDbService.GetAllEnergeticIndicators();
            HighProdNetaRecords = _ecoEnergyDbService.GetRecordsWithProdNetaGreaterThan3000();
            HighGasolinaRecords = _ecoEnergyDbService.GetRecordsWithGasolinaGreaterThan100();
            AverageProdNetaPerYear = _ecoEnergyDbService.GetAverageProdNetaPerYear();
            HighDemandLowProductionRecords = _ecoEnergyDbService.GetRecordsWithHighDemandAndLowProduction();
        }

        public IActionResult OnPostDelete(int id)
        {
            _ecoEnergyDbService.DeleteEnergeticIndicator(id);
            return RedirectToPage();
        }
    }
}
