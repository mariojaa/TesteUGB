using TesteUGB.Models;

namespace TesteUGB.Repositories
{
    public interface IComprasRepository
    {
        Task<List<ComprasModel>> GetAllComprasAsync();
        Task<ComprasModel> GetCompraByIdAsync(int id);
        Task<ComprasModel> AddCompraAsync(ComprasModel compra);
        Task<ComprasModel> Update(ComprasModel obj, int id);
        Task<bool> DeleteCompraAsync(int id);
        Task<ComprasModel> EditarCompras(ComprasModel compras);
        Task<ComprasModel> BuscarPedidoPorIdAsync(int id);
    }
}
