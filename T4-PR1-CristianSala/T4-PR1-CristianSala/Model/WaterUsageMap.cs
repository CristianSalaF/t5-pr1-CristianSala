using CsvHelper.Configuration;

namespace T4_PR1_CristianSala.Model;

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