using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class SiembradedatosCategoriaBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Categoria_Id", "Activo", "FechaCreacion", "Nombre" },
                values: new object[,]
                {
                    { 33, true, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoría 6" },
                    { 34, false, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoría 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Categoria_Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Categoria_Id",
                keyValue: 34);
        }
    }
}
