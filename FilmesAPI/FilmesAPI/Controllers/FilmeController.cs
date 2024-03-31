using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class FilmeController : ControllerBase
    {

        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme);
        }


        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes([FromQueryAttribute] int skip = 0, [FromQueryAttribute] int take = 50)
        {
            return filmes.Skip(skip).Take(take);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaFilmeId(int id)
        {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }

    }
}
