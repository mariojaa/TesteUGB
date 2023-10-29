using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoModel>> Buscar();
        Task<ProdutoModel> FindById(int id);
        Task Insert(ProdutoModel produto);
        Task Update(ProdutoModel produto);
        Task Remove(int id);
        Task<ProdutoModel> FindByNomeProduto(string nomeProduto);
        Task RegistrarEntradaProduto(ProdutoModel produto);
        Task RegistrarSaidaProduto(int produtoId, int quantidadeSaida, string usuario, string departamento);
    }
}
