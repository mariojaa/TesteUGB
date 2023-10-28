using Microsoft.EntityFrameworkCore;
using TesteUGB.Data;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly TesteUGBDbContext _context;

        public ServicoRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicoModel>> Buscar()
        {
          return await _context.Servicos.Include(s => s.Fornecedor).ToListAsync();
            //return await _context.Servicos.ToListAsync();
        }

        public async Task<ServicoModel> FindById(int id)
        {
            return await _context.Servicos.FindAsync(id);
        }

        //public async Task Insert(ServicoModel servico)
        //{
        //    _context.Servicos.Add(servico);
        //    await _context.SaveChangesAsync();
        //}
        public async Task<int> Insert(ServicoModel servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();
            return servico.Id; // Retorna o ID do novo serviço inserido
        }

        public async Task EditarServico(ServicoModel servico)
        {
            _context.Entry(servico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
            }
        }

    }
}
