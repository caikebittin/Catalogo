using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.Api.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into categorias(Nome, ImagemUrl) Values('Bebidas', 'bebidas.jpg')");

            migrationBuilder.Sql("Insert into categorias(Nome, ImagemUrl) Values('Lanches', 'lanches.jpg')");

            migrationBuilder.Sql("Insert into categorias(Nome, ImagemUrl) Values('Sobremesas', 'sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from categorias");
        }
    }
}
