using Microsoft.EntityFrameworkCore;
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
            return await _context.Set<ProdutoModel>().ToListAsync();
        }

        public async Task<ProdutoModel> FindById(int id)
        {
            return await _context.Set<ProdutoModel>().FindAsync(id);
        }

        public async Task Insert(ProdutoModel produto)
        {
            _context.Set<ProdutoModel>().Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task EditarProduto(ProdutoModel produto)
        {
            _context.Set<ProdutoModel>().Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var produto = await _context.Set<ProdutoModel>().FindAsync(id);
            _context.Set<ProdutoModel>().Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
