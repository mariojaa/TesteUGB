using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorModel>> BuscarFornecedores();
        Task<FornecedorModel> FindById(int id);
        Task InserirFornecedor(FornecedorModel fornecedor);
        Task AtualizarFornecedor(FornecedorModel fornecedor);
        Task RemoverFornecedor(int id);
    }
}