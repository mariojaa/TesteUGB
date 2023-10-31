using Microsoft.EntityFrameworkCore;
using System.Data;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        private readonly TesteUGBDbContext _context;
        public ComprasRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public async Task<List<ComprasModel>> GetAllComprasAsync()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task<ComprasModel> GetCompraByIdAsync(int id)
        {
            return await _context.Compras.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ComprasModel> AddCompraAsync(ComprasModel compra)
        {
            _context.Add(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task<ComprasModel> EditarCompras(ComprasModel compras)
        {
            _context.Compras.Update(compras);
            await _context.SaveChangesAsync();
            return compras;
        }


        public async Task<bool> DeleteCompraAsync(int id)
        {
            var obj = await _context.Compras.FindAsync(id);
            if (obj != null)
            {
                _context.Compras.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<ComprasModel> Update(ComprasModel obj, int id)
        {
            if (!await _context.Compras.AnyAsync(x => x.Id == id))
            {
                throw new KeyNotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
        public async Task<ComprasModel> BuscarPedidoPorIdAsync (int id)
        {
            return await _context.Compras.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
