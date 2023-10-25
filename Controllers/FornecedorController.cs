using Microsoft.AspNetCore.Mvc;
using TesteUGB.Models;
using TesteUGB.Repositorio;

namespace TesteUGB.Controllers
{
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorModel>>> GetFornecedores()
        {
            var fornecedores = await _fornecedorRepository.BuscarFornecedores();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorModel>> GetFornecedor(int id)
        {
            var fornecedor = await _fornecedorRepository.FindById(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorModel>> PostFornecedor(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorRepository.InserirFornecedor(fornecedor);
                return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorModel>> DeleteFornecedor(int id)
        {
            var fornecedor = await _fornecedorRepository.FindById(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            await _fornecedorRepository.RemoverFornecedor(id);
            return Ok(fornecedor);
        }
    }
}
