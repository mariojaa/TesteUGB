//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using TesteUGB.Models;

//namespace TesteUGB.Repositorio
//{
//    public interface IServicoRepository
//    {
//        Task<IEnumerable<ServicoModel>> Buscar();
//        Task<ServicoModel> FindById(int id);
//        Task Insert(ServicoModel servico);
//        Task EditarServico(ServicoModel servico);
//        Task Remove(int id);
//    }
//}
using TesteUGB.Models;

public interface IServicoRepository
{
    Task<IEnumerable<ServicoModel>> Buscar();
    Task<ServicoModel> FindById(int id);
    Task<int> Insert(ServicoModel servico); // Retorna um int (ID)
    Task EditarServico(ServicoModel servico);
    Task Remove(int id);
}
