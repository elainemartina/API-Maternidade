using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaternidadeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mães",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profissão = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etnia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoricoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mães", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RNs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    TipoParto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apgar = table.Column<int>(type: "int", nullable: false),
                    CondiçãoMedica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MãeId = table.Column<int>(type: "int", nullable: false),
                    MãeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RNs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RNs_Mães_MãeId",
                        column: x => x.MãeId,
                        principalTable: "Mães",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RNs_Mães_MãeModelId",
                        column: x => x.MãeModelId,
                        principalTable: "Mães",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RNs_MãeId",
                table: "RNs",
                column: "MãeId");

            migrationBuilder.CreateIndex(
                name: "IX_RNs_MãeModelId",
                table: "RNs",
                column: "MãeModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RNs");

            migrationBuilder.DropTable(
                name: "Mães");
        }
    }
}
