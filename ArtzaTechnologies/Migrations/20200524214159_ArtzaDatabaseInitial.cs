using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtzaTechnologies.Migrations
{
    public partial class ArtzaDatabaseInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeroports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longtitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    ConsommationParKm = table.Column<int>(nullable: false),
                    Vitesse = table.Column<float>(nullable: false),
                    EffortDecollage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateDepart = table.Column<DateTime>(nullable: false),
                    DateArrivee = table.Column<DateTime>(nullable: false),
                    AvionId = table.Column<int>(nullable: false),
                    AeroportDepartId = table.Column<int>(nullable: false),
                    AeroportArriveeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vols_Aeroports_AeroportArriveeId",
                        column: x => x.AeroportArriveeId,
                        principalTable: "Aeroports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vols_Aeroports_AeroportDepartId",
                        column: x => x.AeroportDepartId,
                        principalTable: "Aeroports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vols_Avions_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Avions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aeroports",
                columns: new[] { "Id", "Latitude", "Longtitude", "Nom" },
                values: new object[,]
                {
                    { 1, 33.5333, -7.5833, "Mohammed 5" },
                    { 2, 49.009691, 2.547925, "Charles de gualles" },
                    { 3, 48.75, 2.4, "Orly" },
                    { 4, 40.771133, -73.974187, "New york central park" }
                });

            migrationBuilder.InsertData(
                table: "Avions",
                columns: new[] { "Id", "ConsommationParKm", "EffortDecollage", "Libelle", "Type", "Vitesse" },
                values: new object[,]
                {
                    { 1, 5, 10, "Avion 1", "Boeing 1", 450f },
                    { 2, 9, 7, "Avion 2", "Boeing 2", 300f },
                    { 3, 3, 13, "Avion 3", "Boeing 3", 420f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vols_AeroportArriveeId",
                table: "Vols",
                column: "AeroportArriveeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vols_AeroportDepartId",
                table: "Vols",
                column: "AeroportDepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Vols_AvionId",
                table: "Vols",
                column: "AvionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Vols");

            migrationBuilder.DropTable(
                name: "Aeroports");

            migrationBuilder.DropTable(
                name: "Avions");
        }
    }
}
