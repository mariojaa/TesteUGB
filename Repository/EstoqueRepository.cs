using Microsoft.EntityFrameworkCore;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly TesteUGBDbContext _context;

        public EstoqueRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstoqueModel>> Buscar()
        {
            return await _context.Estoque.ToListAsync();
        }

        public async Task<EstoqueModel> FindById(int id)
        {
            return await _context.Estoque.FindAsync(id);
        }

        public async Task Insert(EstoqueModel produto)
        {
            _context.Estoque.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(EstoqueModel produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var produto = await _context.Estoque.FindAsync(id);
            _context.Estoque.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<EstoqueModel> FindByNomeProduto(string nomeProduto)
        {
            return await _context.Estoque.FirstOrDefaultAsync(p => p.NomeProduto == nomeProduto);
        }

        public async Task RegistrarEntradaProduto(EstoqueModel produto)
        {
            var existingProduct = await _context.Estoque.FirstOrDefaultAsync(p => p.NomeProduto == produto.NomeProduto);

            if (existingProduct != null)
            {
                existingProduct.QuantidadeTotalEmEstoque += produto.QuantidadeTotalEmEstoque;
                await Update(existingProduct);
            }
            else
            {
                _context.Estoque.Add(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RegistrarSaidaProduto(int produtoId, int quantidadeSaida, string usuario, string departamento)
        {
            var produtoExistente = await _context.Estoque.FindAsync(produtoId);
            if (produtoExistente != null && produtoExistente.QuantidadeTotalEmEstoque >= quantidadeSaida)
            {
                produtoExistente.QuantidadeTotalEmEstoque -= quantidadeSaida;
                await Update(produtoExistente);
            }
        }
    }
}
