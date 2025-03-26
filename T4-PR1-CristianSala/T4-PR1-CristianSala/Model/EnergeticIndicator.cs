using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;

namespace T4_PR1_CristianSala.Model
{
    public class EnergeticIndicator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Ignore]
        public int? ID { get; set; }
        public string Data { get; set; }
        public double PBEE_Hidroelectr { get; set; }
        public double PBEE_Carbo { get; set; }
        public double PBEE_GasNat { get; set; }
        public double PBEE_FuelOil { get; set; }
        public double PBEE_CiclComb { get; set; }
        public double PBEE_Nuclear { get; set; }
        public double CDEEBC_ProdBruta { get; set; }
        public double CDEEBC_ConsumAux { get; set; }
        public double CDEEBC_ProdNeta { get; set; }
        public double CDEEBC_ConsumBomb { get; set; }
        public double CDEEBC_ProdDisp { get; set; }
        public double CDEEBC_TotVendesXarxaCentral { get; set; }
        public double CDEEBC_SaldoIntercanviElectr { get; set; }
        public double CDEEBC_DemandaElectr { get; set; }
        public string CDEEBC_TotalEBCMercatRegulat { get; set; }
        public string CDEEBC_TotalEBCMercatLliure { get; set; }
        public double? FEE_Industria { get; set; }
        public double? FEE_Terciari { get; set; }
        public double? FEE_Domestic { get; set; }
        public double? FEE_Primari { get; set; }
        public double? FEE_Energetic { get; set; }
        public double? FEEI_ConsObrPub { get; set; }
        public double? FEEI_SiderFoneria { get; set; }
        public double? FEEI_Metalurgia { get; set; }
        public double? FEEI_IndusVidre { get; set; }
        public double? FEEI_CimentsCalGuix { get; set; }
        public double? FEEI_AltresMatConstr { get; set; }
        public double? FEEI_QuimPetroquim { get; set; }
        public double? FEEI_ConstrMedTrans { get; set; }
        public double? FEEI_RestaTransforMetal { get; set; }
        public double? FEEI_AlimBegudaTabac { get; set; }
        public double? FEEI_TextilConfecCuirCalcat { get; set; }
        public double? FEEI_PastaPaperCartro { get; set; }
        public double? FEEI_AltresIndus { get; set; }
        public double? DGGN_PuntFrontEnagas { get; set; }
        public double DGGN_DistrAlimGNL { get; set; }
        public double DGGN_ConsumGNCentrTerm { get; set; }
        public double CCAC_GasolinaAuto { get; set; }
        public double CCAC_GasoilA { get; set; }

        public EnergeticIndicator()
        {
            Data = string.Empty;
            CDEEBC_TotalEBCMercatRegulat = string.Empty;
            CDEEBC_TotalEBCMercatLliure = string.Empty;
        }

        public int GetYear()
        {
            if (int.TryParse(Data, out int year))
            {
                return year;
            }
            return 0;
        }
    }

    public class EnergeticIndicatorMap : ClassMap<EnergeticIndicator>
    {
        public EnergeticIndicatorMap()
        {
            // Map CSV columns to EnergeticIndicator properties
            Map(m => m.Data).Name("Data");
            Map(m => m.PBEE_Hidroelectr).Name("PBEE_Hidroelectr");
            Map(m => m.PBEE_Carbo).Name("PBEE_Carbo");
            Map(m => m.PBEE_GasNat).Name("PBEE_GasNat");
            Map(m => m.PBEE_FuelOil).Name("PBEE_Fuel-Oil");
            Map(m => m.PBEE_CiclComb).Name("PBEE_CiclComb");
            Map(m => m.PBEE_Nuclear).Name("PBEE_Nuclear");
            Map(m => m.CDEEBC_ProdBruta).Name("CDEEBC_ProdBruta");
            Map(m => m.CDEEBC_ConsumAux).Name("CDEEBC_ConsumAux");
            Map(m => m.CDEEBC_ProdNeta).Name("CDEEBC_ProdNeta");
            Map(m => m.CDEEBC_ConsumBomb).Name("CDEEBC_ConsumBomb");
            Map(m => m.CDEEBC_ProdDisp).Name("CDEEBC_ProdDisp");
            Map(m => m.CDEEBC_TotVendesXarxaCentral).Name("CDEEBC_TotVendesXarxaCentral");
            Map(m => m.CDEEBC_SaldoIntercanviElectr).Name("CDEEBC_SaldoIntercanviElectr");
            Map(m => m.CDEEBC_DemandaElectr).Name("CDEEBC_DemandaElectr");
            Map(m => m.CDEEBC_TotalEBCMercatRegulat).Name("CDEEBC_TotalEBCMercatRegulat");
            Map(m => m.CDEEBC_TotalEBCMercatLliure).Name("CDEEBC_TotalEBCMercatLliure");
            Map(m => m.FEE_Industria).Name("FEE_Industria");
            Map(m => m.FEE_Terciari).Name("FEE_Terciari");
            Map(m => m.FEE_Domestic).Name("FEE_Domestic");
            Map(m => m.FEE_Primari).Name("FEE_Primari");
            Map(m => m.FEE_Energetic).Name("FEE_Energetic");
            Map(m => m.FEEI_ConsObrPub).Name("FEEI_ConsObrPub");
            Map(m => m.FEEI_SiderFoneria).Name("FEEI_SiderFoneria");
            Map(m => m.FEEI_Metalurgia).Name("FEEI_Metalurgia");
            Map(m => m.FEEI_IndusVidre).Name("FEEI_IndusVidre");
            Map(m => m.FEEI_CimentsCalGuix).Name("FEEI_CimentsCalGuix");
            Map(m => m.FEEI_AltresMatConstr).Name("FEEI_AltresMatConstr");
            Map(m => m.FEEI_QuimPetroquim).Name("FEEI_QuimPetroquim");
            Map(m => m.FEEI_ConstrMedTrans).Name("FEEI_ConstrMedTrans");
            Map(m => m.FEEI_RestaTransforMetal).Name("FEEI_RestaTransforMetal");
            Map(m => m.FEEI_AlimBegudaTabac).Name("FEEI_AlimBegudaTabac");
            Map(m => m.FEEI_TextilConfecCuirCalcat).Name("FEEI_TextilConfecCuirCalçat");
            Map(m => m.FEEI_PastaPaperCartro).Name("FEEI_PastaPaperCartro");
            Map(m => m.FEEI_AltresIndus).Name("FEEI_AltresIndus");
            Map(m => m.DGGN_PuntFrontEnagas).Name("DGGN_PuntFrontEnagas");
            Map(m => m.DGGN_DistrAlimGNL).Name("DGGN_DistrAlimGNL");
            Map(m => m.DGGN_ConsumGNCentrTerm).Name("DGGN_ConsumGNCentrTerm");
            Map(m => m.CCAC_GasolinaAuto).Name("CCAC_GasolinaAuto");
            Map(m => m.CCAC_GasoilA).Name("CCAC_GasoilA");

            // Ignore the ID as it will be auto-generated
            Map(m => m.ID).Ignore();
        }
    }
}
