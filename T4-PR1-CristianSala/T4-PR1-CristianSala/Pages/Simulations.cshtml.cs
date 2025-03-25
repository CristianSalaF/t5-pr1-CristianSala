using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1_CristianSala.Model;
using T4_PR1_CristianSala.Service;

namespace T4_PR1_CristianSala.Pages
{
    public class SimulationsModel : PageModel
    {
        private readonly EcoEnergyDbService _ecoEnergyDbService;
        public List<BaseSimulation> Simulations { get; set; }

        public SimulationsModel(EcoEnergyDbService ecoEnergyDbService)
        {
            _ecoEnergyDbService = ecoEnergyDbService;
            Simulations = new List<BaseSimulation>();
        }

        public void OnGet()
        {
            Simulations = _ecoEnergyDbService.GetAllSimulations();
        }
    }
}
