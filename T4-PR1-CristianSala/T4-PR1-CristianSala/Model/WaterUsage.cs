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

    public class WaterUsageMap : ClassMap<WaterUsage>
    {
        public WaterUsageMap()
        {
            Map(m => m.Any).Name("Any");
            Map(m => m.CodiComarca).Name("Codi comarca");
            Map(m => m.Comarca).Name("Comarca");
            Map(m => m.Poblacio).Name("Població");
            Map(m => m.DomesticXarxa).Name("Domèstic xarxa");
            Map(m => m.ActivitatsEconomiquesIFontsPropies).Name("Activitats econòmiques i fonts pròpies");
            Map(m => m.Total).Name("Total");
            Map(m => m.ConsumDomesticPerCapita).Name("Consum domèstic per càpita");
        }
    }
}
