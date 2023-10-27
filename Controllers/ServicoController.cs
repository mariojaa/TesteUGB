using Microsoft.AspNetCore.Mvc;
using TesteUGB.Models;
using TesteUGB.Repositorio;

namespace TesteUGB.Controllers
{
    [Route("api/servico")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _servicoRepository;

        public ServicoController(ServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoModel>>> BuscarServicos()
        {
            try
            {
                var usuarios = await _servicoRepository.Buscar();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoModel>> BuscarServicos(int id)
        {
            var usuario = await _servicoRepository.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        [HttpPost]
        public async Task<ActionResult<ServicoModel>> InserirServico(ServicoModel servico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _servicoRepository.Insert(servico);
                    return CreatedAtAction(nameof(InserirServico), new { id = servico.Id }, servico);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarServico(int id, ServicoModel servico)
        {
            if (id != servico.Id)
            {
                return BadRequest();
            }

            try
            {
                await _servicoRepository.EditarServico(servico);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoModel>> DeleteServico(int id)
        {
            var usuario = await _servicoRepository.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                await _servicoRepository.Remove(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

    }
}
