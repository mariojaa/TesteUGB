using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TesteUGB.Models;

public class ServicoModel
{
    [Key]
    public int Id { get; set; }
    public string NomeDoServico { get; set; }
    public string DescricaoDoServico { get; set; }
    public DateTime PrazoEntregaPadrao { get; set; }

    [ForeignKey("Fornecedor")]
    public int FornecedorId { get; set; }

    [InverseProperty("Servicos")]
    public FornecedorModel Fornecedor { get; set; }
}
