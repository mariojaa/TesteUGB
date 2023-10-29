using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly TesteUGBDbContext _context;

        public ComprasController(TesteUGBDbContext context)
        {
            _context = context;
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

            // Adiciona a compra ao contexto do Entity Framework para persistência.
            _context.Compras.Add(compra);
            _context.SaveChanges(); // Salva no banco de dados.

            return CreatedAtAction("Get", new { id = compra.Id }, compra);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ComprasModel compra)
        {
            var existingCompra = _context.Compras.Find(id);
            if (existingCompra == null)
            {
                return NotFound();
            }

            // Atualiza os dados da compra existente com os novos dados.
            existingCompra.NomeProduto = compra.NomeProduto;
            existingCompra.CodigoDaSolicitacao = compra.CodigoDaSolicitacao;
            existingCompra.Fabricante = compra.Fabricante;
            existingCompra.QuantidadeSolicitada = compra.QuantidadeSolicitada;
            existingCompra.DepartamentoSolicitante = compra.DepartamentoSolicitante;
            existingCompra.DataSolicitada = compra.DataSolicitada;
            existingCompra.DataPrevisaoEntregaProduto = compra.DataPrevisaoEntregaProduto;
            existingCompra.TipoDoProduto = compra.TipoDoProduto;
            existingCompra.ValorUnitarioDoProduto = compra.ValorUnitarioDoProduto;

            // Recalcula o ValorTotal após a atualização.
            existingCompra.ValorTotal = existingCompra.QuantidadeSolicitada * existingCompra.ValorUnitarioDoProduto;

            existingCompra.NumeroNotaFiscalProduto = compra.NumeroNotaFiscalProduto;
            existingCompra.CodigoEAN = compra.CodigoEAN;

            _context.SaveChanges(); // Salva as alterações no banco de dados.

            return NoContent();
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
