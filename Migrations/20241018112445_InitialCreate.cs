using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelKayıtSistemi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    Adres = table.Column<string>(type: "TEXT", nullable: true),
                    Maas = table.Column<decimal>(type: "TEXT", nullable: false),
                    Resim = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "PersonelKayıtları",
                columns: table => new
                {
                    KayitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonelId = table.Column<int>(type: "INTEGER", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelKayıtları", x => x.KayitId);
                    table.ForeignKey(
                        name: "FK_PersonelKayıtları_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelKayıtları_PersonelId",
                table: "PersonelKayıtları",
                column: "PersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelKayıtları");

            migrationBuilder.DropTable(
                name: "Personeller");
        }
    }
}
