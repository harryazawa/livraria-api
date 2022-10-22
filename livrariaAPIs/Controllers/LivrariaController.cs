using livrariaAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivrariaController : ControllerBase
{
    private readonly ToDoContext _context;

    public LivrariaController(ToDoContext context)
    {
        _context = context;
        
        foreach (Produto x in _context.ToDoProducts)
            _context.ToDoProducts.Remove(x);
        _context.SaveChanges();
        
        _context.ToDoProducts.Add(new Produto { ID = 1, Nome = "Alice no País das Maravilhas", Preco = 24.0, Quantidade = 1, Categoria = "Fantasia", Img = "img1"});
        _context.ToDoProducts.Add(new Produto { ID = 2, Nome = "Senhor dos Anéis: As Duas Torres", Preco = 34.0, Quantidade = 1, Categoria = "Fantasia", Img = "img2"});
        _context.ToDoProducts.Add(new Produto { ID = 3, Nome = "Sandman Vol. 1", Preco = 44.0, Quantidade = 1, Categoria = "Fantasia", Img = "img3"});
        _context.ToDoProducts.Add(new Produto { ID = 4, Nome = "Blade Runner: Androides sonham com ovelhas elétricas?", Preco = 54.0, Quantidade = 1, Categoria = "Cyberpunk", Img = "img4"});
        _context.ToDoProducts.Add(new Produto { ID = 5, Nome = "Fiction Lane", Preco = 64.0, Quantidade = 1, Categoria = "Fantasia", Img = "img5"});

        _context.SaveChanges();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await _context.ToDoProducts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetItem(int id)
    {
        var item = await _context.ToDoProducts.FindAsync(id.ToString());

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto)
    {
        _context.ToDoProducts.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItem), new { id = produto.ID }, produto);
    }
}