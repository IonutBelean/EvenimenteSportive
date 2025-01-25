using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvenimenteSportive.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvenimenteSportive_Locatii_LocatieID",
                table: "EvenimenteSportive");

            migrationBuilder.DropForeignKey(
                name: "FK_Participanti_EvenimenteSportive_EvenimentSportivID",
                table: "Participanti");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsori_EvenimenteSportive_EvenimentSportivID",
                table: "Sponsori");

            migrationBuilder.DropIndex(
                name: "IX_Sponsori_EvenimentSportivID",
                table: "Sponsori");

            migrationBuilder.DropIndex(
                name: "IX_Participanti_EvenimentSportivID",
                table: "Participanti");

            migrationBuilder.DropIndex(
                name: "IX_EvenimenteSportive_LocatieID",
                table: "EvenimenteSportive");

            migrationBuilder.DropColumn(
                name: "EvenimentSportivID",
                table: "Sponsori");

            migrationBuilder.DropColumn(
                name: "EvenimentSportivID",
                table: "Participanti");

            migrationBuilder.DropColumn(
                name: "LocatieID",
                table: "EvenimenteSportive");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Locatii",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Locatii",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "EvenimenteSportive",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsori_IDEveniment",
                table: "Sponsori",
                column: "IDEveniment");

            migrationBuilder.CreateIndex(
                name: "IX_Participanti_IDEveniment",
                table: "Participanti",
                column: "IDEveniment");

            migrationBuilder.CreateIndex(
                name: "IX_EvenimenteSportive_IDLocatie",
                table: "EvenimenteSportive",
                column: "IDLocatie");

            migrationBuilder.AddForeignKey(
                name: "FK_EvenimenteSportive_Locatii_IDLocatie",
                table: "EvenimenteSportive",
                column: "IDLocatie",
                principalTable: "Locatii",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participanti_EvenimenteSportive_IDEveniment",
                table: "Participanti",
                column: "IDEveniment",
                principalTable: "EvenimenteSportive",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsori_EvenimenteSportive_IDEveniment",
                table: "Sponsori",
                column: "IDEveniment",
                principalTable: "EvenimenteSportive",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvenimenteSportive_Locatii_IDLocatie",
                table: "EvenimenteSportive");

            migrationBuilder.DropForeignKey(
                name: "FK_Participanti_EvenimenteSportive_IDEveniment",
                table: "Participanti");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsori_EvenimenteSportive_IDEveniment",
                table: "Sponsori");

            migrationBuilder.DropIndex(
                name: "IX_Sponsori_IDEveniment",
                table: "Sponsori");

            migrationBuilder.DropIndex(
                name: "IX_Participanti_IDEveniment",
                table: "Participanti");

            migrationBuilder.DropIndex(
                name: "IX_EvenimenteSportive_IDLocatie",
                table: "EvenimenteSportive");

            migrationBuilder.AddColumn<int>(
                name: "EvenimentSportivID",
                table: "Sponsori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvenimentSportivID",
                table: "Participanti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Locatii",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Locatii",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "EvenimenteSportive",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LocatieID",
                table: "EvenimenteSportive",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsori_EvenimentSportivID",
                table: "Sponsori",
                column: "EvenimentSportivID");

            migrationBuilder.CreateIndex(
                name: "IX_Participanti_EvenimentSportivID",
                table: "Participanti",
                column: "EvenimentSportivID");

            migrationBuilder.CreateIndex(
                name: "IX_EvenimenteSportive_LocatieID",
                table: "EvenimenteSportive",
                column: "LocatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_EvenimenteSportive_Locatii_LocatieID",
                table: "EvenimenteSportive",
                column: "LocatieID",
                principalTable: "Locatii",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participanti_EvenimenteSportive_EvenimentSportivID",
                table: "Participanti",
                column: "EvenimentSportivID",
                principalTable: "EvenimenteSportive",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsori_EvenimenteSportive_EvenimentSportivID",
                table: "Sponsori",
                column: "EvenimentSportivID",
                principalTable: "EvenimenteSportive",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
