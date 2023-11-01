public interface IServicoRepository
{
    Task<IEnumerable<ServicoModel>> Buscar();
    Task<ServicoModel> FindById(int id);
    Task<int> Insert(ServicoModel servico); // Retorna um int (ID)
    Task EditarServico(ServicoModel servico);
    Task Remove(int id);
}