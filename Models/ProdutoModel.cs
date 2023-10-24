﻿namespace TesteUGB.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int NumeroPedidoProduto { get; set; }
        public string FornecedorProduto { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int QuantidadeMinimaEmEstoque { get; set; }
        public int MyProperty { get; set; }
        public string SetorDeDeposito { get; set; }
        public DateTime DataCadastroProduto { get; set; }
        public DateTime DataPrevisaoEntregaProduto { get; set; }
        public string TipoDoProdutoUnitarioOuPacote { get; set; }
        public int ValorUnitarioDoProduto { get; set; }
        public long NumeroNotaFiscalProduto { get; set; }
        public long CodigoEAN { get; set; } //Codigo de Barras do Produto
    }
}
