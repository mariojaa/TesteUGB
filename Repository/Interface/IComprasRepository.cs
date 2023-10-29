using TesteUGB.Models;

namespace TesteUGB.Repositories
{
    public interface IComprasRepository
    {
        List<ComprasModel> GetAllCompras();
        ComprasModel GetCompraById(int id);
        void AddCompra(ComprasModel compra);
        Task<ComprasModel> Update(ComprasModel obj, int id);
        void DeleteCompra(int id);
        Task<ComprasModel> EditarCompras(ComprasModel compras);
    }
}
