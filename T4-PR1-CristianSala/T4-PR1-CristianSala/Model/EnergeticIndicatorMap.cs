using CsvHelper.Configuration;

namespace T4_PR1_CristianSala.Model;

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