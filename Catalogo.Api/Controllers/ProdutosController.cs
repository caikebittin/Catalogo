using Catalogo.Api.Context;
using Catalogo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly CatalogoDbContext _context;

    public ProdutosController(CatalogoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        try
        {
            var produtos = _context.Produtos.Take(10).AsNoTracking().ToList();

            if (produtos is null)
                return NotFound("Produtos não encontrados.");

            return produtos;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro na solicitação com o servidor.", ex);
        }
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        try
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound("Produto não encontrado.");

            return produto;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro na solicitação com o servidor.", ex);
        }
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        try
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }
        catch (Exception ex)
        {

            throw new Exception("Erro ao inserir valor no Banco de Dados", ex);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        try
        {
            if (id != produto.ProdutoId)
                return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possivel atualizar o item com o ID= {id}", ex);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possivel deletar o item com o ID= {id}", ex);
        }

    }
}
