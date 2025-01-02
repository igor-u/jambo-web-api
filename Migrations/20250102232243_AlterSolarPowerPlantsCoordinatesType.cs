using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jambo.Migrations
{
    /// <inheritdoc />
    public partial class AlterSolarPowerPlantsCoordinatesType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Coordinates",
                table: "SolarPowerPlants",
                type: "varchar(19)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(19)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Coordinates",
                table: "SolarPowerPlants",
                type: "nvarchar(19)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(19)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
