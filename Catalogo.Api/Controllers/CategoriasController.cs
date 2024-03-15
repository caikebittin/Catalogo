using Catalogo.Api.Context;
using Catalogo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : Controller
{
    private readonly CatalogoDbContext _context;

    public CategoriasController(CatalogoDbContext context)
    {
        _context = context;
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).AsNoTracking().ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        try
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();

            if (categorias is null)
                return NotFound("Categorias não encontradas.");

            return categorias;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro na sua solicitação com o servidor.", ex);
        }


    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        try
        {
            var categorias = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);

            if (categorias is null)
                return NotFound($"Categoria com o ID= {id} não foi encontrada.");

            return categorias;

        }
        catch (Exception ex)
        {

            throw new Exception("Erro na sua solicitação", ex);
        }
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        try
        {
            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao inserir valor no Banco de Dados", ex);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        try
        {
            if (id != categoria.CategoriaId)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }
        catch (Exception ex)
        {

            throw new Exception($"Não foi possivel atualizar a categoria com o ID= {id}", ex);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
                return NotFound($"Categoria com o ID= {id} não encontrada.");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possivel deletar a categoria com o ID= {id}.", ex);
        }
    }
}
