using Microsoft.AspNetCore.Mvc;
using TesteUGB.Models;
using TesteUGB.Repositorio;

namespace TesteUGB.Controllers
{
    [Route("api/estoque")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueController(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstoqueModel>>> BuscarProdutos()
        {
            try
            {
                var produtos = await _estoqueRepository.Buscar();
                return Ok(produtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueModel>> BuscarProduto(int id)
        {
            var produto = await _estoqueRepository.FindById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<EstoqueModel>> InserirProduto([FromBody] EstoqueModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _estoqueRepository.Insert(produto);
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
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] EstoqueModel produtoEditado)
        {
            if (produtoEditado == null || produtoEditado.Id != id)
            {
                return BadRequest();
            }

            try
            {
                var produtoExistente = await _estoqueRepository.FindById(id);
                if (produtoExistente == null)
                {
                    return NotFound();
                }

                await _estoqueRepository.Update(produtoEditado);

                return Ok(produtoEditado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EstoqueModel>> DeletarProduto(int id)
        {
            var produto = await _estoqueRepository.FindById(id);
            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                await _estoqueRepository.Remove(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }
    }
}
