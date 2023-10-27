using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteUGB.Models
{
    public class ServicoModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeDoServico { get; set; }
        public string DescricaoDoServico { get; set; }
        public DateTime PrazoEntregaPadrao { get; set; } //Prazo Padrão para o tempo de serviço ser entregue (até x dias)
        //[ForeignKey("ServicoId")]
        //public int FornecedorId { get; set; }
        //public FornecedorModel Fornecedor { get; set; }
    }
}