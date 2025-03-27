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

        /// <summary>
        /// Create a dummy simulation object with the correct type, then save it to the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IActionResult OnPostDelete(int id, string type)
        {
            BaseSimulation simulationToDelete = type switch
            {
                "Sistema Solar" => new SolarEnergy { ID = id },
                "Sistema Eòlic" => new WindEnergy { ID = id },
                "Sistema Hidroelèctric" => new HydroEnergy { ID = id },
                _ => throw new ArgumentException("Tipus de simulació desconegut")
            };

            _ecoEnergyDbService.DeleteSimulation(id, simulationToDelete);
            return RedirectToPage();
        }
    }
}
