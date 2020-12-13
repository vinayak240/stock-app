using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CompanyService.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CEO = table.Column<string>(nullable: true),
                    BoardOfDirectors = table.Column<string>(nullable: true),
                    Turnover = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StockExchanges = table.Column<string>(nullable: true),
                    SectorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyCode);
                });

            migrationBuilder.CreateTable(
                name: "Ipos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    StockExchange = table.Column<string>(nullable: true),
                    PricePerShare = table.Column<float>(nullable: false),
                    TotalShares = table.Column<int>(nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ipos_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockPrices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StockExchange = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CompanyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockPrices_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ipos_CompanyCode",
                table: "Ipos",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyCode",
                table: "StockPrices",
                column: "CompanyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ipos");

            migrationBuilder.DropTable(
                name: "StockPrices");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
