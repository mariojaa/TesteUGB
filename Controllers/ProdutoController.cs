using Microsoft.AspNetCore.Mvc;
using TesteUGB.Models;
using TesteUGB.Repositorio;

namespace TesteUGB.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> BuscarProdutos()
        {
            try
            {
                var produtos = await _produtoRepository.Buscar();
                return Ok(produtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProduto(int id)
        {
            var produto = await _produtoRepository.FindById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> InserirProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _produtoRepository.Insert(produto);
                    return CreatedAtAction(nameof(BuscarProduto), new { id = produto.Id }, produto);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, ProdutoModel produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _produtoRepository.EditarProduto(produto);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> DeletarProduto(int id)
        {
            var produto = await _produtoRepository.FindById(id);
            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                await _produtoRepository.Remove(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }
    }
}
