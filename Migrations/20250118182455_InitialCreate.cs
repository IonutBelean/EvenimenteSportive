using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvenimenteSportive.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locatii",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatii", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvenimenteSportive",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDLocatie = table.Column<int>(type: "int", nullable: false),
                    LocatieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenimenteSportive", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvenimenteSportive_Locatii_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locatii",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participanti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    Echipa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDEveniment = table.Column<int>(type: "int", nullable: false),
                    EvenimentSportivID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participanti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participanti_EvenimenteSportive_EvenimentSportivID",
                        column: x => x.EvenimentSportivID,
                        principalTable: "EvenimenteSportive",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sponsori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurataContract = table.Column<int>(type: "int", nullable: false),
                    IDEveniment = table.Column<int>(type: "int", nullable: false),
                    EvenimentSportivID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsori", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sponsori_EvenimenteSportive_EvenimentSportivID",
                        column: x => x.EvenimentSportivID,
                        principalTable: "EvenimenteSportive",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvenimenteSportive_LocatieID",
                table: "EvenimenteSportive",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Participanti_EvenimentSportivID",
                table: "Participanti",
                column: "EvenimentSportivID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsori_EvenimentSportivID",
                table: "Sponsori",
                column: "EvenimentSportivID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participanti");

            migrationBuilder.DropTable(
                name: "Sponsori");

            migrationBuilder.DropTable(
                name: "EvenimenteSportive");

            migrationBuilder.DropTable(
                name: "Locatii");
        }
    }
}
