﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.Api.Migrations
{
    /// <inheritdoc />
    public partial class populaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                                "Values('Coca Cola Zero', 'Refrigerante de Cola 350 ml', 5.45, 'cocacola.png', 50, now(), 1)");
            
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                                "Values('X Salada', 'Lanche de Hamburger 150g com Queijo e Alface', 16.50, 'xsalada.png', 10, now(), 2)");
            
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                                "Values('Pudim 100g', 'Pudim de Leite Condensado 100g', 6.75, 'pudim.png', 20, now(), 3)");
        }
        
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from produtos");
        }
    }
}
