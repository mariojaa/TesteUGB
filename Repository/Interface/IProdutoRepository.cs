using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoModel>> Buscar();
        Task<ProdutoModel> FindById(int id);
        Task Insert(ProdutoModel produto);
        Task EditarProduto(ProdutoModel produto);
        Task Remove(int id);
    }
}
