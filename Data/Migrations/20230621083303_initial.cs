using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Etudiants_App_Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculte",
                columns: table => new
                {
                    FaculteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculte", x => x.FaculteId);
                });

            migrationBuilder.CreateTable(
                name: "Niveau",
                columns: table => new
                {
                    NiveauId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaculteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveau", x => x.NiveauId);
                    table.ForeignKey(
                        name: "FK_Niveau_Faculte_FaculteId",
                        column: x => x.FaculteId,
                        principalTable: "Faculte",
                        principalColumn: "FaculteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolumeHoraires = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiveauId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursId);
                    table.ForeignKey(
                        name: "FK_Cours_Niveau_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveau",
                        principalColumn: "NiveauId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    EtudiantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeEtudiant = table.Column<int>(type: "int", nullable: false),
                    NiveauId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.EtudiantID);
                    table.ForeignKey(
                        name: "FK_Etudiant_Niveau_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveau",
                        principalColumn: "NiveauId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cours_NiveauId",
                table: "Cours",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_NiveauId",
                table: "Etudiant",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Niveau_FaculteId",
                table: "Niveau",
                column: "FaculteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Niveau");

            migrationBuilder.DropTable(
                name: "Faculte");
        }
    }
}
