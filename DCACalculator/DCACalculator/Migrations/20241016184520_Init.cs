using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCACalculator.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalData",
                columns: table => new
                {
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    symbol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    open = table.Column<float>(type: "real", nullable: false),
                    high = table.Column<float>(type: "real", nullable: false),
                    low = table.Column<float>(type: "real", nullable: false),
                    close = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "HistoricalData_date_IDX",
                table: "HistoricalData",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "HistoricalData_symbol_IDX",
                table: "HistoricalData",
                column: "symbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalData");
        }
    }
}
