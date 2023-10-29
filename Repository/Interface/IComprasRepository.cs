using TesteUGB.Models;

namespace TesteUGB.Repositories
{
    public interface IComprasRepository
    {
        List<ComprasModel> GetAllCompras();
        ComprasModel GetCompraById(int id);
        void AddCompra(ComprasModel compra);
        void UpdateCompra(int id, ComprasModel compra);
        void DeleteCompra(int id);
    }
}
