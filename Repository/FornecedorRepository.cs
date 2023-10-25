using Microsoft.EntityFrameworkCore;
using System.Data;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly TesteUGBDbContext _context;

        public FornecedorRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FornecedorModel>> BuscarFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<FornecedorModel> FindById(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task InserirFornecedor(FornecedorModel fornecedor)
        {
            if (fornecedor == null)
                throw new ArgumentNullException(nameof(fornecedor));

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarFornecedor(FornecedorModel fornecedor)
        {
            if (fornecedor == null)
                throw new ArgumentNullException(nameof(fornecedor));

            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
