using Microsoft.EntityFrameworkCore;
using System.Data;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        private List<ComprasModel> compras = new List<ComprasModel>();
        private readonly TesteUGBDbContext _context;
        public ComprasRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public List<ComprasModel> GetAllCompras()
        {
            return compras;
        }

        public ComprasModel GetCompraById(int id)
        {
            return compras.FirstOrDefault(c => c.Id == id);
        }

        public void AddCompra(ComprasModel compra)
        {
            compras.Add(compra);
        }

        public async Task<ComprasModel> EditarCompras(ComprasModel compras)
        {
            _context.Compras.Update(compras);
            await _context.SaveChangesAsync();
            return compras;
        }


        public void DeleteCompra(int id)
        {
            var compra = compras.FirstOrDefault(c => c.Id == id);
            if (compra != null)
            {
                compras.Remove(compra);
            }
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
    }
}
