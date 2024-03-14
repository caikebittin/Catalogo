using Catalogo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Context;

public class CatalogoDbContext : DbContext
{
    public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
    {}

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
