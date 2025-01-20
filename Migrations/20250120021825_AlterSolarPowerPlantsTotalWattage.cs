using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jambo.Migrations
{
    /// <inheritdoc />
    public partial class AlterSolarPowerPlantsTotalWattage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalSolarInverterWattage",
                table: "SolarPowerPlants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSolarPanelWattage",
                table: "SolarPowerPlants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSolarInverterWattage",
                table: "SolarPowerPlants");

            migrationBuilder.DropColumn(
                name: "TotalSolarPanelWattage",
                table: "SolarPowerPlants");
        }
    }
}
