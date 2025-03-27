using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Service;

public partial class EcoEnergyDbService
{
    public List<EnergeticIndicator> GetAllEnergeticIndicators()
    {
        return _context.Set<EnergeticIndicator>().ToList();
    }

    public List<EnergeticIndicator> GetRecordsWithProdNetaGreaterThan3000()
    {
        return _context.EnergeticIndicators.Where(e => e.CDEEBC_ProdNeta > 3000).ToList();
    }

    public List<EnergeticIndicator> GetRecordsWithGasolinaGreaterThan100()
    {
        return _context.EnergeticIndicators.Where(e => e.CCAC_GasolinaAuto > 100).ToList();
    }

    public List<dynamic> GetAverageProdNetaPerYear()
    {
        return _context.EnergeticIndicators.GroupBy(e => e.Data)
            .Select(g => new
            {
                Any = g.Key,
                AverageProdNeta = g.Average(e => e.CDEEBC_ProdNeta)
            }).ToList<dynamic>();
    }

    public List<EnergeticIndicator> GetRecordsWithHighDemandAndLowProduction()
    {
        return _context.EnergeticIndicators.Where(e => e.CDEEBC_DemandaElectr > 1000 && e.CDEEBC_ProdNeta < 1000)
            .ToList();
    }

    public void SaveEnergeticIndicator(EnergeticIndicator energeticIndicator)
    {
        _context.EnergeticIndicators.Add(energeticIndicator);
        _context.SaveChanges();
    }

    public void DeleteEnergeticIndicator(int id)
    {
        var energeticIndicator = _context.Set<EnergeticIndicator>().Find(id);
        if (energeticIndicator != null)
        {
            _context.EnergeticIndicators.Remove(energeticIndicator);
            _context.SaveChanges();
        }
    }
}