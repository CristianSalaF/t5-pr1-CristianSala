using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;

namespace T4_PR1_CristianSala.Model
{
    public class WaterUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Ignore]
        //this is set to null so EF Core will auto-generate the values, check SeedWaterUsagesAsync() in Services/EcoEnergySeedingService
        public int? ID { get; set; } = null;
        public int Any { get; set; }
        public int CodiComarca { get; set; }
        public string Comarca { get; set; } = string.Empty;
        public int Poblacio { get; set; }
        public int DomesticXarxa { get; set; }
        public int ActivitatsEconomiquesIFontsPropies { get; set; }
        public int Total { get; set; }
        public double ConsumDomesticPerCapita { get; set; }
    }
}
