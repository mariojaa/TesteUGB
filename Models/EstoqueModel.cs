using System;
using TesteUGB.Models.Enum;

namespace TesteUGB.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeTotalEmEstoque { get; set; }
        public int QuantidadeMinimaEmEstoque { get; set; }
        public string SetorDeDeposito { get; set; }
        public DateTime DataCadastroProduto { get; set; }
        public TipoDoProdutoEnum TipoDoProdutoUnitarioOuPacote { get; set; }
        public long NumeroNotaFiscalProduto { get; set; }
        public long CodigoEAN { get; set; }
    }
}
