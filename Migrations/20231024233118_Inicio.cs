using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteUGB.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresaFornecedora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEnderecoFornecedor = table.Column<int>(type: "int", nullable: false),
                    BairroEnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeEnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoEnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisEnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJFornecedor = table.Column<long>(type: "bigint", nullable: false),
                    InscricaoEstadualEMunicipalFornecedor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPedidoProduto = table.Column<int>(type: "int", nullable: false),
                    FornecedorProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMinimaEmEstoque = table.Column<int>(type: "int", nullable: false),
                    SetorDeDeposito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastroProduto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevisaoEntregaProduto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDoProdutoUnitarioOuPacote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitarioDoProduto = table.Column<int>(type: "int", nullable: false),
                    NumeroNotaFiscalProduto = table.Column<long>(type: "bigint", nullable: false),
                    CodigoEAN = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoDoServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrazoEntregaPadrao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaUsuario = table.Column<int>(type: "int", nullable: false),
                    NomeCompletoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
