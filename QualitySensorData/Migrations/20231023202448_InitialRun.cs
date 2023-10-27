using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualitySensorData.Migrations
{
    /// <inheritdoc />
    public partial class InitialRun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualitySensorDataTable",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    floor = table.Column<int>(type: "int", nullable: false),
                    SensorID = table.Column<int>(type: "int", nullable: false),
                    pH = table.Column<int>(type: "int", nullable: false),
                    turbidity = table.Column<int>(type: "int", nullable: false),
                    conductivity = table.Column<int>(type: "int", nullable: false),
                    co2 = table.Column<int>(type: "int", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    temp = table.Column<int>(type: "int", nullable: false),
                    clorin = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualitySensorDataTable", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualitySensorDataTable");
        }
    }
}
