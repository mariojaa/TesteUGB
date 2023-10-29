using Microsoft.AspNetCore.Mvc;
using TesteUGB.Models;
using TesteUGB.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AtualizarProduto(int id, EstoqueModel produtoEditado)
        {
            if (id != produtoEditado.Id)
            {
                return BadRequest();
            }

            try
            {
                await _estoqueRepository.Update(produtoEditado);
                return NoContent();

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

        [HttpPatch("{id}/entrada")]
        public async Task<ActionResult<EstoqueModel>> EntradaProduto(int id, [FromBody] int quantidade)
        {
            try
            {
                var produto = await _estoqueRepository.FindById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                if (quantidade <= 0)
                {
                    return BadRequest("A quantidade de entrada deve ser maior que zero.");
                }

                produto.QuantidadeTotalEmEstoque += quantidade;
                await _estoqueRepository.Update(produto);

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpPatch("{id}/saida")]
        public async Task<ActionResult<EstoqueModel>> SaidaProduto(int id, [FromBody] int quantidade)
        {
            try
            {
                var produto = await _estoqueRepository.FindById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                if (quantidade <= 0 || quantidade > produto.QuantidadeTotalEmEstoque)
                {
                    return BadRequest("A quantidade de saída não é válida.");
                }

                produto.QuantidadeTotalEmEstoque -= quantidade;
                await _estoqueRepository.Update(produto);

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpPatch("{id}/{acao}")]
        public async Task<ActionResult<EstoqueModel>> AtualizarEstoque(int id, string acao, [FromBody] EstoqueModel model)
        {
            var produto = await _estoqueRepository.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }

            if (acao == "entrada")
            {
                if (model.Quantidade <= 0)
                {
                    return BadRequest("A quantidade de entrada deve ser maior que zero.");
                }

                produto.QuantidadeTotalEmEstoque += model.Quantidade;
            }
            else if (acao == "saida")
            {
                if (model.Quantidade <= 0 || model.Quantidade > produto.QuantidadeTotalEmEstoque)
                {
                    return BadRequest("A quantidade de saída não é válida.");
                }

                produto.QuantidadeTotalEmEstoque -= model.Quantidade;
            }
            else
            {
                return BadRequest("Ação inválida.");
            }

            try
            {
                await _estoqueRepository.Update(produto);
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }
    }
}
