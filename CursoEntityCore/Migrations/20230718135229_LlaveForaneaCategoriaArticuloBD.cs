using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class LlaveForaneaCategoriaArticuloBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categoria",
                newName: "Categoria_Id");

            migrationBuilder.AddColumn<int>(
                name: "Categoria_Id",
                table: "Tbl_articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_articulo_Categoria_Id",
                table: "Tbl_articulo",
                column: "Categoria_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_articulo_Categoria_Categoria_Id",
                table: "Tbl_articulo",
                column: "Categoria_Id",
                principalTable: "Categoria",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_articulo_Categoria_Categoria_Id",
                table: "Tbl_articulo");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_articulo_Categoria_Id",
                table: "Tbl_articulo");

            migrationBuilder.DropColumn(
                name: "Categoria_Id",
                table: "Tbl_articulo");

            migrationBuilder.RenameColumn(
                name: "Categoria_Id",
                table: "Categoria",
                newName: "Id");
        }
    }
}
