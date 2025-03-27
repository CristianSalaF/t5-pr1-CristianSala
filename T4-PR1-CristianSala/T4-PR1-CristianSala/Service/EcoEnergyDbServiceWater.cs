using T4_PR1_CristianSala.Model;

namespace T4_PR1_CristianSala.Service;

public partial class EcoEnergyDbService
{
    public List<WaterUsage> GetAllWaterUsages()
    {
        return _context.Set<WaterUsage>().ToList();
    }

    public List<WaterUsage> GetTop10MunicipisWithHighestConsum()
    {
        return _context.WaterUsages.OrderByDescending(w => w.Total).Take(10).ToList();
    }

    public List<dynamic> GetAverageUsageByComarca()
    {
        return _context.WaterUsages.GroupBy(w => w.Comarca)
            .Select(g => new
            {
                Comarca = g.Key,
                AverageConsum = g.Average(w => w.ConsumDomesticPerCapita)
            }).ToList<dynamic>();
    }

    public List<WaterUsage> GetSuspiciousUsageValues()
    {
        return _context.WaterUsages.Where(w => w.Total >= 1000000).ToList();
    }

    public void SaveWaterUsage(WaterUsage waterUsage)
    {
        _context.WaterUsages.Add(waterUsage);
        _context.SaveChanges();
    }

    public void DeleteWaterUsage(int id)
    {
        var waterUsage = _context.Set<WaterUsage>().Find(id);
        if (waterUsage != null)
        {
            _context.WaterUsages.Remove(waterUsage);
            _context.SaveChanges();
        }
    }
}