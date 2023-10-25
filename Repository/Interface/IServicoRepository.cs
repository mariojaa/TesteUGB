using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteUGB.Models;

namespace TesteUGB.Repositorio
{
    public interface IServicoRepository
    {
        Task<IEnumerable<ServicoModel>> Buscar();
        Task<ServicoModel> FindById(int id);
        Task Insert(ServicoModel servico);
        Task EditarServico(ServicoModel servico);
        Task Remove(int id);
    }
}