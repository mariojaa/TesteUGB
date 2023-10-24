using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> BuscarPorEmailELogin(string email, string login);
        Task<UsuarioModel> BuscarPorLogin(string login);
        Task<List<UsuarioModel>> Buscar();
        Task<bool> Remove(int id);
        Task<UsuarioModel> Insert(UsuarioModel usuarios);
        Task<UsuarioModel> Update(UsuarioModel usuarios, int id);
        Task<UsuarioModel> FindById(int id);
        Task<UsuarioModel> EditarUsuario(UsuarioModel usuarios);
    }
}
