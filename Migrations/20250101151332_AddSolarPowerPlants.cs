using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jambo.Migrations
{
    /// <inheritdoc />
    public partial class AddSolarPowerPlants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SolarPowerPlantId",
                table: "SolarPanels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SolarPowerPlantId",
                table: "SolarInverters",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SolarPowerPlants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Coordinates = table.Column<string>(type: "nvarchar(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarPowerPlants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SolarPanels_SolarPowerPlantId",
                table: "SolarPanels",
                column: "SolarPowerPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarInverters_SolarPowerPlantId",
                table: "SolarInverters",
                column: "SolarPowerPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarInverters_SolarPowerPlants_SolarPowerPlantId",
                table: "SolarInverters",
                column: "SolarPowerPlantId",
                principalTable: "SolarPowerPlants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarPanels_SolarPowerPlants_SolarPowerPlantId",
                table: "SolarPanels",
                column: "SolarPowerPlantId",
                principalTable: "SolarPowerPlants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarInverters_SolarPowerPlants_SolarPowerPlantId",
                table: "SolarInverters");

            migrationBuilder.DropForeignKey(
                name: "FK_SolarPanels_SolarPowerPlants_SolarPowerPlantId",
                table: "SolarPanels");

            migrationBuilder.DropTable(
                name: "SolarPowerPlants");

            migrationBuilder.DropIndex(
                name: "IX_SolarPanels_SolarPowerPlantId",
                table: "SolarPanels");

            migrationBuilder.DropIndex(
                name: "IX_SolarInverters_SolarPowerPlantId",
                table: "SolarInverters");

            migrationBuilder.DropColumn(
                name: "SolarPowerPlantId",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "SolarPowerPlantId",
                table: "SolarInverters");
        }
    }
}
