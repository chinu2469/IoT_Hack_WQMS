using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualitySensorData.Migrations
{
    /// <inheritdoc />
    public partial class readyModelsNoLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rewardPoint = table.Column<long>(type: "bigint", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "MainTankdata");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
