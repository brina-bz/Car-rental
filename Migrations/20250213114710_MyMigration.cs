using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odpelji_me.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avtomobil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Znamka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leto = table.Column<int>(type: "int", nullable: false),
                    CenaNaDan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegistrskaStevilka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avtomobil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uporabnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vloga = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mnenje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    AvtomobilId = table.Column<int>(type: "int", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mnenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mnenje_Avtomobil_AvtomobilId",
                        column: x => x.AvtomobilId,
                        principalTable: "Avtomobil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mnenje_Uporabnik_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    AvtomobilId = table.Column<int>(type: "int", nullable: false),
                    DatumZacetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumKonca = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Avtomobil_AvtomobilId",
                        column: x => x.AvtomobilId,
                        principalTable: "Avtomobil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Uporabnik_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placilo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervacijaId = table.Column<int>(type: "int", nullable: false),
                    Znesek = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NacinPlacila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placilo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placilo_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mnenje_AvtomobilId",
                table: "Mnenje",
                column: "AvtomobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Mnenje_UporabnikId",
                table: "Mnenje",
                column: "UporabnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Placilo_RezervacijaId",
                table: "Placilo",
                column: "RezervacijaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_AvtomobilId",
                table: "Rezervacija",
                column: "AvtomobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_UporabnikId",
                table: "Rezervacija",
                column: "UporabnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mnenje");

            migrationBuilder.DropTable(
                name: "Placilo");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Avtomobil");

            migrationBuilder.DropTable(
                name: "Uporabnik");
        }
    }
}
