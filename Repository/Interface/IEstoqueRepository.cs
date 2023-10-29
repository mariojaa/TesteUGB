using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<EstoqueModel>> Buscar();
        Task<EstoqueModel> FindById(int id);
        Task Insert(EstoqueModel produto);
        Task Update(EstoqueModel produto);
        Task Remove(int id);
        Task<EstoqueModel> FindByNomeProduto(string nomeProduto);
        Task RegistrarEntradaProduto(EstoqueModel produto);
        Task RegistrarSaidaProduto(int produtoId, int quantidadeSaida, string usuario, string departamento);
    }
}
