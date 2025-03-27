using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1_CristianSala.Model;
using T4_PR1_CristianSala.Service;

namespace T4_PR1_CristianSala.Pages
{
    public class WaterUsagesModel : PageModel
    {
        private readonly EcoEnergyDbService _ecoEnergyDbService;

        public List<WaterUsage> Usages { get; set; }
        public List<WaterUsage> Top10Municipis { get; set; }
        public List<dynamic> AverageConsumByComarca { get; set; }
        public List<WaterUsage> SuspiciousValues { get; set; }

        public WaterUsagesModel(EcoEnergyDbService ecoEnergyDbService)
        {
            _ecoEnergyDbService = ecoEnergyDbService;
            Usages = new List<WaterUsage>();
            Top10Municipis = new List<WaterUsage>();
            AverageConsumByComarca = new List<dynamic>();
            SuspiciousValues = new List<WaterUsage>();
        }

        public void OnGet()
        {
            Usages = _ecoEnergyDbService.GetAllWaterUsages();
            Top10Municipis = _ecoEnergyDbService.GetTop10MunicipisWithHighestConsum();
            AverageConsumByComarca = _ecoEnergyDbService.GetAverageUsageByComarca();
            SuspiciousValues = _ecoEnergyDbService.GetSuspiciousUsageValues();
        }

        public IActionResult OnPostDelete(int id)
        {
            _ecoEnergyDbService.DeleteWaterUsage(id);
            return RedirectToPage();
        }
    }
}
