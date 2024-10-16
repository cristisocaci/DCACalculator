using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCACalculator.Migrations
{
    /// <inheritdoc />
    public partial class Investments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPlanProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestmentPlanId = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountInvestedEur = table.Column<double>(type: "float", nullable: false),
                    AmountOwned = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPlanProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentPlanProgress_InvestmentPlans_InvestmentPlanId",
                        column: x => x.InvestmentPlanId,
                        principalTable: "InvestmentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPlanProgress_InvestmentPlanId",
                table: "InvestmentPlanProgress",
                column: "InvestmentPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentPlanProgress");

            migrationBuilder.DropTable(
                name: "InvestmentPlans");
        }
    }
}
