using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace maple_web_api.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoveragePlans",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(nullable: false),
                    EligibilityDateFrom = table.Column<DateTime>(nullable: false),
                    EligibilityDateTo = table.Column<DateTime>(nullable: false),
                    EligibilityCountry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoveragePlans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RateCharts",
                columns: table => new
                {
                    RateId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CuttoffAge = table.Column<int>(nullable: false),
                    NetPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateCharts", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_RateCharts_CoveragePlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "CoveragePlans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractItems",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    CoverageId = table.Column<int>(nullable: false),
                    NetPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItems", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_ContractItems_CoveragePlans_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "CoveragePlans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoveragePlans",
                columns: new[] { "PlanId", "EligibilityCountry", "EligibilityDateFrom", "EligibilityDateTo", "PlanName" },
                values: new object[] { 1, 0, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold" });

            migrationBuilder.InsertData(
                table: "CoveragePlans",
                columns: new[] { "PlanId", "EligibilityCountry", "EligibilityDateFrom", "EligibilityDateTo", "PlanName" },
                values: new object[] { 2, 1, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Platinum" });

            migrationBuilder.InsertData(
                table: "CoveragePlans",
                columns: new[] { "PlanId", "EligibilityCountry", "EligibilityDateFrom", "EligibilityDateTo", "PlanName" },
                values: new object[] { 3, 2, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silver" });

            migrationBuilder.InsertData(
                table: "RateCharts",
                columns: new[] { "RateId", "CuttoffAge", "Gender", "NetPrice", "PlanId" },
                values: new object[,]
                {
                    { 1L, 41, 0, 1000, 1 },
                    { 2L, 200, 0, 2000, 1 },
                    { 3L, 41, 1, 1200, 1 },
                    { 4L, 200, 1, 2500, 1 },
                    { 9L, 41, 0, 1900, 2 },
                    { 10L, 200, 0, 2900, 2 },
                    { 11L, 41, 1, 2100, 2 },
                    { 12L, 200, 1, 3200, 2 },
                    { 5L, 41, 0, 1500, 3 },
                    { 6L, 200, 0, 2600, 3 },
                    { 7L, 41, 1, 1900, 3 },
                    { 8L, 200, 1, 2800, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_CoverageId",
                table: "ContractItems",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_CustomerId",
                table: "ContractItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RateCharts_PlanId",
                table: "RateCharts",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractItems");

            migrationBuilder.DropTable(
                name: "RateCharts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CoveragePlans");
        }
    }
}
