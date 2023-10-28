using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualitySensorData.Migrations
{
    /// <inheritdoc />
    public partial class ReadyAPI10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumptionData",
                columns: table => new
                {
                    sensorid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sfloor = table.Column<int>(type: "int", nullable: false),
                    consuption = table.Column<int>(type: "int", nullable: false),
                    utilityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionData", x => x.sensorid);
                });

            migrationBuilder.CreateTable(
                name: "floorWiseConsumptionData",
                columns: table => new
                {
                    floor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    consumptionOnFoor = table.Column<float>(type: "real", nullable: false),
                    consumptionPercent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floorWiseConsumptionData", x => x.floor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumptionData");

            migrationBuilder.DropTable(
                name: "floorWiseConsumptionData");
        }
    }
}
