using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualitySensorData.Migrations
{
    /// <inheritdoc />
    public partial class datatypeupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumptionData",
                columns: table => new
                {
                    sensorid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sfloor = table.Column<int>(type: "int", nullable: false),
                    consuption = table.Column<int>(type: "int", nullable: false),
                    utilityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "MainTankdata",
                columns: table => new
                {
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    waterLevel = table.Column<float>(type: "real", nullable: false),
                    refillCount = table.Column<int>(type: "int", nullable: false),
                    consumptionTotal = table.Column<float>(type: "real", nullable: false),
                    totalSensorCount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTankdata", x => x.date);
                });

            migrationBuilder.CreateTable(
                name: "QualitySensorDataTable",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    floor = table.Column<int>(type: "int", nullable: false),
                    SensorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pH = table.Column<float>(type: "real", nullable: false),
                    turbidity = table.Column<float>(type: "real", nullable: false),
                    conductivity = table.Column<float>(type: "real", nullable: false),
                    co2 = table.Column<float>(type: "real", nullable: false),
                    humidity = table.Column<float>(type: "real", nullable: false),
                    temp = table.Column<float>(type: "real", nullable: false),
                    clorin = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualitySensorDataTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rewardPoint = table.Column<long>(type: "bigint", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.empId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumptionData");

            migrationBuilder.DropTable(
                name: "floorWiseConsumptionData");

            migrationBuilder.DropTable(
                name: "MainTankdata");

            migrationBuilder.DropTable(
                name: "QualitySensorDataTable");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
