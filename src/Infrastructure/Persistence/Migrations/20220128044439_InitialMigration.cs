using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeeloApi.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    IdOwner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Photo = table.Column<string>(type: "varchar(150)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.IdOwner);
                });

            migrationBuilder.CreateTable(
                name: "Propertys",
                columns: table => new
                {
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(28,4)", precision: 28, scale: 4, nullable: false),
                    CodeInternal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertys", x => x.IdProperty);
                    table.ForeignKey(
                        name: "FK_Propertys_Owners_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Owners",
                        principalColumn: "IdOwner");
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    IdPropertyImage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProperty = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.IdPropertyImage);
                    table.ForeignKey(
                        name: "FK_PropertyImages_Propertys_IdProperty",
                        column: x => x.IdProperty,
                        principalTable: "Propertys",
                        principalColumn: "IdProperty");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTraces",
                columns: table => new
                {
                    IdPropertyTrace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,4)", precision: 28, scale: 4, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(28,4)", precision: 28, scale: 4, nullable: false),
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTraces", x => x.IdPropertyTrace);
                    table.ForeignKey(
                        name: "FK_PropertyTraces_Propertys_IdProperty",
                        column: x => x.IdProperty,
                        principalTable: "Propertys",
                        principalColumn: "IdProperty");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_IdProperty",
                table: "PropertyImages",
                column: "IdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_Propertys_IdOwner",
                table: "Propertys",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTraces_IdProperty",
                table: "PropertyTraces",
                column: "IdProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropTable(
                name: "PropertyTraces");

            migrationBuilder.DropTable(
                name: "Propertys");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
