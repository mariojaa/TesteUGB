﻿using System.ComponentModel.DataAnnotations.Schema;
using TesteUGB.Models.Enum;

namespace TesteUGB.Models
{
    public class ComprasModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int CodigoDaSolicitacao { get; set; }
        public string Fabricante { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string DepartamentoSolicitante { get; set; }
        public DateTime DataSolicitada { get; set; }
        public DateTime DataPrevisaoEntregaProduto { get; set; }
        public TipoDoProdutoEnum TipoDoProduto { get; set; }
        public double ValorUnitarioDoProduto { get; set; }
        public double ValorTotal { get; set; } // Soma do valor unitario x quantidade
        public long NumeroNotaFiscalProduto { get; set; }
        public long CodigoEAN { get; set; } // Código de Barras do Produto
    }
}

