using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaternidadeAPI.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RNs_Mães_MãeModelId",
                table: "RNs");

            migrationBuilder.DropIndex(
                name: "IX_RNs_MãeModelId",
                table: "RNs");

            migrationBuilder.DropColumn(
                name: "MãeModelId",
                table: "RNs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MãeModelId",
                table: "RNs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RNs_MãeModelId",
                table: "RNs",
                column: "MãeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RNs_Mães_MãeModelId",
                table: "RNs",
                column: "MãeModelId",
                principalTable: "Mães",
                principalColumn: "Id");
        }
    }
}
