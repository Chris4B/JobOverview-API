using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobOverview.Data.Migrations
{
    /// <inheritdoc />
    public partial class JeuDeDonnées : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Millesime",
                table: "Versions",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.InsertData(
                table: "Filières",
                columns: new[] { "CodeFiliere", "Nom" },
                values: new object[,]
                {
                    { "BIOA", "biologie animale" },
                    { "BIOH", "Bologie Humaine" },
                    { "BIOV", "Biologie Végétale" }
                });

            migrationBuilder.InsertData(
                table: "Logiciels",
                columns: new[] { "CodeLogiciel", "CodeFiliere", "Nom" },
                values: new object[,]
                {
                    { "ANATOMIA", "BIOH", "Anatomia" },
                    { "GENOMICA", "BIOH", "Génomica" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "CodeModule", "CodeLogiciel", "CodeLogicielParent", "CodeModuleParent", "Nom" },
                values: new object[,]
                {
                    { "FONC", "GENOMICA", null, null, "Anatomie fonctionnelle" },
                    { "MICRO", "GENOMICA", null, null, "Anatomie microscopique" },
                    { "PARAMETRES", "GENOMICA", null, null, "Paramètres" },
                    { "PATHO", "GENOMICA", null, null, "Anatomie pathologique" },
                    { "POLYMORPGYSME", "GENOMICA", null, null, "Polymorphisme génétique" },
                    { "RADIO", "GENOMICA", null, null, "Anatomie radiologique" },
                    { "SEQUENCAGE", "GENOMICA", null, null, "Séquencage" },
                    { "TOPO", "GENOMICA", null, null, "Anatomie topographique" },
                    { "UTILS_ROLES", "GENOMICA", null, null, "utilisateurs et rôles" },
                    { "VAR_ALLELE", "GENOMICA", null, null, "Varaitions alletiques" }
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "NumeroVersion", "CodeLogiciel", "DateOuverture", "DateSortiePrevue", "DateSortieReelle", "Millesime" },
                values: new object[,]
                {
                    { 1f, "GENOMICA", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023 },
                    { 2f, "GENOMICA", new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2024 },
                    { 4.5f, "ANATOMIA", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 5f, "ANATOMIA", new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023 },
                    { 5.5f, "ANATOMIA", new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "CodeModule", "CodeLogiciel", "CodeLogicielParent", "CodeModuleParent", "Nom" },
                values: new object[,]
                {
                    { "ANALYSE", "GENOMICA", "GENOMICA", "SEQUENCAGE", "Analyse" },
                    { "MARQUAGE", "GENOMICA", "GENOMICA", "SEQUENCAGE", "Marquage" },
                    { "SEPARATION", "GENOMICA", "GENOMICA", "SEQUENCAGE", "Séparation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filières",
                keyColumn: "CodeFiliere",
                keyValue: "BIOA");

            migrationBuilder.DeleteData(
                table: "Filières",
                keyColumn: "CodeFiliere",
                keyValue: "BIOV");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "ANALYSE");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "FONC");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "MARQUAGE");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "MICRO");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "PARAMETRES");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "PATHO");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "POLYMORPGYSME");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "RADIO");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "SEPARATION");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "TOPO");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "UTILS_ROLES");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "VAR_ALLELE");

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "NumeroVersion",
                keyValue: 1f);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "NumeroVersion",
                keyValue: 2f);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "NumeroVersion",
                keyValue: 4.5f);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "NumeroVersion",
                keyValue: 5f);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "NumeroVersion",
                keyValue: 5.5f);

            migrationBuilder.DeleteData(
                table: "Logiciels",
                keyColumn: "CodeLogiciel",
                keyValue: "ANATOMIA");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "CodeModule",
                keyValue: "SEQUENCAGE");

            migrationBuilder.DeleteData(
                table: "Logiciels",
                keyColumn: "CodeLogiciel",
                keyValue: "GENOMICA");

            migrationBuilder.DeleteData(
                table: "Filières",
                keyColumn: "CodeFiliere",
                keyValue: "BIOH");

            migrationBuilder.AlterColumn<short>(
                name: "Millesime",
                table: "Versions",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
