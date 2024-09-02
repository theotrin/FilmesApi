using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new();
    private static int id = 0;

    [HttpPost]
    public void AdcionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
    }

    [HttpGet]
    public IEnumerable<Filme> VerFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Filme? VerFilmePorId(int id)
    {
       return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
