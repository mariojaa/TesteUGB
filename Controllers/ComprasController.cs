using Microsoft.AspNetCore.Mvc;
using TesteUGB.Data;
using TesteUGB.Models;
using TesteUGB.Repositories;

namespace TesteUGB.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly TesteUGBDbContext _context;
        private readonly ComprasRepository _comprasRepository;

        public ComprasController(TesteUGBDbContext context, ComprasRepository comprasRepository)
        {
            _context = context;
            _comprasRepository = comprasRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var compras = _context.Compras.ToList();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra == null)
            {
                return NotFound();
            }
            return Ok(compra);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ComprasModel compra)
        {
            // Calcular o ValorTotal com base na QuantidadeSolicitada e ValorUnitarioDoProduto.
            compra.ValorTotal = compra.QuantidadeSolicitada * compra.ValorUnitarioDoProduto;

            _context.Compras.Add(compra);
            _context.SaveChanges();

            return CreatedAtAction("Get", new { id = compra.Id }, compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarCompra(int id, ComprasModel compras)
        {
            if (id != compras.Id)
            {
                return BadRequest();
            }

            try
            {
                await _comprasRepository.EditarCompras(compras);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            // Remove a compra do contexto e salva as alterações no banco de dados.
            _context.Compras.Remove(compra);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
