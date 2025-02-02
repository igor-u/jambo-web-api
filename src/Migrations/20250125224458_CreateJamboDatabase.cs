using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jambo.Migrations
{
    /// <inheritdoc />
    public partial class CreateJamboDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SolarPowerPlants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Coordinates = table.Column<string>(type: "varchar(19)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalSolarPanelWattage = table.Column<int>(type: "int", nullable: false),
                    TotalSolarInverterWattage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarPowerPlants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SolarInverters",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RatedPower = table.Column<int>(type: "int", nullable: false),
                    PeakPower = table.Column<int>(type: "int", nullable: false),
                    SolarPowerPlantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarInverters", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_SolarInverters_SolarPowerPlants_SolarPowerPlantId",
                        column: x => x.SolarPowerPlantId,
                        principalTable: "SolarPowerPlants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SolarPanels",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Power = table.Column<int>(type: "int", nullable: false),
                    SolarPowerPlantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarPanels", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_SolarPanels_SolarPowerPlants_SolarPowerPlantId",
                        column: x => x.SolarPowerPlantId,
                        principalTable: "SolarPowerPlants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SolarInverters_SolarPowerPlantId",
                table: "SolarInverters",
                column: "SolarPowerPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarPanels_SolarPowerPlantId",
                table: "SolarPanels",
                column: "SolarPowerPlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolarInverters");

            migrationBuilder.DropTable(
                name: "SolarPanels");

            migrationBuilder.DropTable(
                name: "SolarPowerPlants");
        }
    }
}
