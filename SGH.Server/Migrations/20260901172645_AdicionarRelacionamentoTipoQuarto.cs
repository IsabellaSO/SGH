using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGH.Server.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoTipoQuarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoQuartoId",
                table: "Quartos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_TipoQuartoId",
                table: "Quartos",
                column: "TipoQuartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quartos_TipoQuarto_TipoQuartoId",
                table: "Quartos",
                column: "TipoQuartoId",
                principalTable: "TipoQuarto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quartos_TipoQuarto_TipoQuartoId",
                table: "Quartos");

            migrationBuilder.DropIndex(
                name: "IX_Quartos_TipoQuartoId",
                table: "Quartos");

            migrationBuilder.DropColumn(
                name: "TipoQuartoId",
                table: "Quartos");
        }
    }
}
