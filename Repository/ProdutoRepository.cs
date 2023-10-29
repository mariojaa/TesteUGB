using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly TesteUGBDbContext _context;

        public ProdutoRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoModel>> Buscar()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> FindById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task Insert(ProdutoModel produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProdutoModel produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<ProdutoModel> FindByNomeProduto(string nomeProduto)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.NomeProduto == nomeProduto);
        }

        public async Task RegistrarEntradaProduto(ProdutoModel produto)
        {
            var existingProduct = await _context.Produtos.FirstOrDefaultAsync(p => p.NomeProduto == produto.NomeProduto);

            if (existingProduct != null)
            {
                existingProduct.QuantidadeTotalEmEstoque += produto.QuantidadeTotalEmEstoque;
                await Update(existingProduct);
            }
            else
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RegistrarSaidaProduto(int produtoId, int quantidadeSaida, string usuario, string departamento)
        {
            var produtoExistente = await _context.Produtos.FindAsync(produtoId);
            if (produtoExistente != null && produtoExistente.QuantidadeTotalEmEstoque >= quantidadeSaida)
            {
                produtoExistente.QuantidadeTotalEmEstoque -= quantidadeSaida;
                await Update(produtoExistente);
            }
        }
    }
}
