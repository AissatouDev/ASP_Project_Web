using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Etudiants_App_Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class etudiantModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiant_Faculte_FaculteId",
                table: "Etudiant");

            migrationBuilder.DropForeignKey(
                name: "FK_Niveau_Faculte_FaculteId",
                table: "Niveau");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiant_Faculte_FaculteId",
                table: "Etudiant",
                column: "FaculteId",
                principalTable: "Faculte",
                principalColumn: "FaculteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Niveau_Faculte_FaculteId",
                table: "Niveau",
                column: "FaculteId",
                principalTable: "Faculte",
                principalColumn: "FaculteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiant_Faculte_FaculteId",
                table: "Etudiant");

            migrationBuilder.DropForeignKey(
                name: "FK_Niveau_Faculte_FaculteId",
                table: "Niveau");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiant_Faculte_FaculteId",
                table: "Etudiant",
                column: "FaculteId",
                principalTable: "Faculte",
                principalColumn: "FaculteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Niveau_Faculte_FaculteId",
                table: "Niveau",
                column: "FaculteId",
                principalTable: "Faculte",
                principalColumn: "FaculteId");
        }
    }
}
