using TesteUGB.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TesteUGB.Data;

namespace TesteUGB.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TesteUGBDbContext _context;

        public UsuarioRepository(TesteUGBDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> Buscar()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> FindById(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Insert(UsuarioModel usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Remove(int id)
        {
            var obj = await _context.Usuarios.FindAsync(id);
            if (obj != null)
            {
                _context.Usuarios.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UsuarioModel> Update(UsuarioModel obj, int id)
        {
            if (!await _context.Usuarios.AnyAsync(x => x.Id == id))
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

        public async Task<UsuarioModel> EditarUsuario(UsuarioModel usuarios)
        {
            _context.Usuarios.Update(usuarios);
            await _context.SaveChangesAsync();
            return usuarios;
        }

        public async Task<UsuarioModel> BuscarPorLogin(string login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioLogin.ToUpper() == login.ToUpper());
        }

        public async Task<UsuarioModel> BuscarPorEmailELogin(string email, string login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.EmailUsuario.ToUpper() == email.ToUpper() && x.UsuarioLogin.ToUpper() == login.ToUpper());
        }
    }
}
