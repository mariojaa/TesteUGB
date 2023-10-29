using TesteUGB.Models;

namespace TesteUGB.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        private List<ComprasModel> compras = new List<ComprasModel>();

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

        public void UpdateCompra(int id, ComprasModel compra)
        {
            var existingCompra = compras.FirstOrDefault(c => c.Id == id);
            if (existingCompra != null)
            {
                // Atualiza os dados da compra existente com os novos dados.
                existingCompra.NomeProduto = compra.NomeProduto;
                existingCompra.CodigoDaSolicitacao = compra.CodigoDaSolicitacao;
                existingCompra.Fabricante = compra.Fabricante;
                existingCompra.QuantidadeSolicitada = compra.QuantidadeSolicitada;
                existingCompra.DepartamentoSolicitante = compra.DepartamentoSolicitante;
                existingCompra.DataSolicitada = compra.DataSolicitada;
                existingCompra.DataPrevisaoEntregaProduto = compra.DataPrevisaoEntregaProduto;
                existingCompra.TipoDoProduto = compra.TipoDoProduto;
                existingCompra.ValorUnitarioDoProduto = compra.ValorUnitarioDoProduto;
                existingCompra.ValorTotal = compra.QuantidadeSolicitada * compra.ValorUnitarioDoProduto;
                existingCompra.NumeroNotaFiscalProduto = compra.NumeroNotaFiscalProduto;
                existingCompra.CodigoEAN = compra.CodigoEAN;
            }
        }

        public void DeleteCompra(int id)
        {
            var compra = compras.FirstOrDefault(c => c.Id == id);
            if (compra != null)
            {
                compras.Remove(compra);
            }
        }
    }
}
