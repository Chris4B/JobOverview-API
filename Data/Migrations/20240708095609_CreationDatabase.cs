using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOverview.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreationDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filières",
                columns: table => new
                {
                    CodeFiliere = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CodeFiliere", x => x.CodeFiliere);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    NumeroRelease = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePublication = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NumeroVersion = table.Column<float>(type: "real", nullable: false),
                    CodeLogiciel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_NumeroRelease", x => x.NumeroRelease);
                });

            migrationBuilder.CreateTable(
                name: "Logiciels",
                columns: table => new
                {
                    CodeLogiciel = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CodeFiliere = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CodeLogiciel", x => x.CodeLogiciel);
                    table.ForeignKey(
                        name: "FK_Logiciels_Filières_CodeFiliere",
                        column: x => x.CodeFiliere,
                        principalTable: "Filières",
                        principalColumn: "CodeFiliere");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    CodeModule = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CodeModuleParent = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CodeLogiciel = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CodeLogicielParent = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CodeModule", x => x.CodeModule);
                    table.UniqueConstraint("AK_Modules_CodeModule_CodeLogiciel", x => new { x.CodeModule, x.CodeLogiciel });
                    table.ForeignKey(
                        name: "FK_Modules_Logiciels_CodeLogiciel",
                        column: x => x.CodeLogiciel,
                        principalTable: "Logiciels",
                        principalColumn: "CodeLogiciel");
                    table.ForeignKey(
                        name: "FK_Modules_Modules_CodeModuleParent_CodeLogicielParent",
                        columns: x => new { x.CodeModuleParent, x.CodeLogicielParent },
                        principalTable: "Modules",
                        principalColumns: new[] { "CodeModule", "CodeLogiciel" });
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    NumeroVersion = table.Column<float>(type: "real", nullable: false),
                    Millesime = table.Column<short>(type: "smallint", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortiePrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortieReelle = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodeLogiciel = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_NumeroVersion", x => x.NumeroVersion);
                    table.ForeignKey(
                        name: "FK_Versions_Logiciels_CodeLogiciel",
                        column: x => x.CodeLogiciel,
                        principalTable: "Logiciels",
                        principalColumn: "CodeLogiciel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logiciels_CodeFiliere",
                table: "Logiciels",
                column: "CodeFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CodeLogiciel",
                table: "Modules",
                column: "CodeLogiciel");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CodeModuleParent_CodeLogicielParent",
                table: "Modules",
                columns: new[] { "CodeModuleParent", "CodeLogicielParent" });

            migrationBuilder.CreateIndex(
                name: "IX_Versions_CodeLogiciel",
                table: "Versions",
                column: "CodeLogiciel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Logiciels");

            migrationBuilder.DropTable(
                name: "Filières");
        }
    }
}
