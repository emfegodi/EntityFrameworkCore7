using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarTablaYColumnaArticuloBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "Tbl_articulo");

            migrationBuilder.RenameColumn(
                name: "TituloArticulo",
                table: "Tbl_articulo",
                newName: "Titulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_articulo",
                table: "Tbl_articulo",
                column: "ArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_articulo",
                table: "Tbl_articulo");

            migrationBuilder.RenameTable(
                name: "Tbl_articulo",
                newName: "Articulo");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Articulo",
                newName: "TituloArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "ArticuloId");
        }
    }
}
