using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4_PR1_CristianSala.Model
{
    public abstract class BaseSimulation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime SimulationDate { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public double Ratio { get; set; }
        public double EnergyGenerated { get; set; }
        public double CostPerKWh { get; set; }
        public double PricePerKWh { get; set; }
        public double TotalCost => EnergyGenerated * CostPerKWh;
        public double TotalPrice => EnergyGenerated * PricePerKWh;
        
        /// <summary>
        /// Used for child classes so that they can add their own parameters by type
        /// </summary>
        public abstract string ParameterName { get; }
        public abstract double ParameterValue { get; set; }
    }
}
