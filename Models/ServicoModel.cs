using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TesteUGB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    public string NomeEmpresaFornecedora { get; set; } // Nome da empresa fornecedora
    public int ServicoId { get; set; }
}
