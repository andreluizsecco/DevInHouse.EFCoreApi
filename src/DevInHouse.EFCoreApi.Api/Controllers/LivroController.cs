using DevInHouse.EFCoreApi.Core.Entities;
using DevInHouse.EFCoreApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevInHouse.EFCoreApi.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public ActionResult<List<Livro>> ObterLivros(string? titulo)
        {
            var livros = _livroService.ObterLivros(titulo);
            if (livros == null || livros.Count == 0)
                return NoContent();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public ActionResult<Livro> ObterLivroPorId(int id)
        {
            var livro = _livroService.ObterPorId(id);
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public ActionResult CriarLivro(Livro livro)
        {
            var id = _livroService.CriarLivro(livro);
            return CreatedAtAction(nameof(ObterLivroPorId), new { Id = id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarLivro(int id, Livro livro)
        {
            var livroOriginal = _livroService.ObterPorId(id);
            if (livro == null)
                return NotFound();

            _livroService.AtualizarLivro(livroOriginal, livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult ExcluirLivro(int id)
        {
            try
            {
                _livroService.RemoverLivro(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("não existe"))
                    return NotFound();
                
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = ex.Message });
            }
        }
    }
}