using TesteUGB.Models;

public class SolicitacaoServicoModel
{
    public int Id { get; set; }
    public int ServicoId { get; set; }
    public int FornecedorId { get; set; }
    public ServicoModel Servico { get; set; }
    public FornecedorModel Fornecedor { get; set; }
}
