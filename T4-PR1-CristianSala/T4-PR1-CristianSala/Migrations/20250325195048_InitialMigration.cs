using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T4_PR1_CristianSala.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergeticIndicators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PBEE_Hidroelectr = table.Column<double>(type: "float", nullable: false),
                    PBEE_Carbo = table.Column<double>(type: "float", nullable: false),
                    PBEE_GasNat = table.Column<double>(type: "float", nullable: false),
                    PBEE_FuelOil = table.Column<double>(type: "float", nullable: false),
                    PBEE_CiclComb = table.Column<double>(type: "float", nullable: false),
                    PBEE_Nuclear = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ProdBruta = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ConsumAux = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ProdNeta = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ConsumBomb = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ProdDisp = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_TotVendesXarxaCentral = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_SaldoIntercanviElectr = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_DemandaElectr = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_TotalEBCMercatRegulat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDEEBC_TotalEBCMercatLliure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FEE_Industria = table.Column<double>(type: "float", nullable: false),
                    FEE_Terciari = table.Column<double>(type: "float", nullable: false),
                    FEE_Domestic = table.Column<double>(type: "float", nullable: false),
                    FEE_Primari = table.Column<double>(type: "float", nullable: false),
                    FEE_Energetic = table.Column<double>(type: "float", nullable: false),
                    FEEI_ConsObrPub = table.Column<double>(type: "float", nullable: false),
                    FEEI_SiderFoneria = table.Column<double>(type: "float", nullable: false),
                    FEEI_Metalurgia = table.Column<double>(type: "float", nullable: false),
                    FEEI_IndusVidre = table.Column<double>(type: "float", nullable: false),
                    FEEI_CimentsCalGuix = table.Column<double>(type: "float", nullable: false),
                    FEEI_AltresMatConstr = table.Column<double>(type: "float", nullable: false),
                    FEEI_QuimPetroquim = table.Column<double>(type: "float", nullable: false),
                    FEEI_ConstrMedTrans = table.Column<double>(type: "float", nullable: false),
                    FEEI_RestaTransforMetal = table.Column<double>(type: "float", nullable: false),
                    FEEI_AlimBegudaTabac = table.Column<double>(type: "float", nullable: false),
                    FEEI_TextilConfecCuirCalcat = table.Column<double>(type: "float", nullable: false),
                    FEEI_PastaPaperCartro = table.Column<double>(type: "float", nullable: false),
                    FEEI_AltresIndus = table.Column<double>(type: "float", nullable: false),
                    DGGN_PuntFrontEnagas = table.Column<double>(type: "float", nullable: false),
                    DGGN_DistrAlimGNL = table.Column<double>(type: "float", nullable: false),
                    DGGN_ConsumGNCentrTerm = table.Column<double>(type: "float", nullable: false),
                    CCAC_GasolinaAuto = table.Column<double>(type: "float", nullable: false),
                    CCAC_GasoilA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergeticIndicators", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SimulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Ratio = table.Column<double>(type: "float", nullable: false),
                    EnergyGenerated = table.Column<double>(type: "float", nullable: false),
                    CostPerKWh = table.Column<double>(type: "float", nullable: false),
                    PricePerKWh = table.Column<double>(type: "float", nullable: false),
                    ParameterValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WaterUsages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Any = table.Column<int>(type: "int", nullable: false),
                    CodiComarca = table.Column<int>(type: "int", nullable: false),
                    Comarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poblacio = table.Column<int>(type: "int", nullable: false),
                    DomesticXarxa = table.Column<int>(type: "int", nullable: false),
                    ActivitatsEconomiquesIFontsPropies = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    ConsumDomesticPerCapita = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterUsages", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergeticIndicators");

            migrationBuilder.DropTable(
                name: "Simulations");

            migrationBuilder.DropTable(
                name: "WaterUsages");
        }
    }
}
