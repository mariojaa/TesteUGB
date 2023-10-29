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
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoDaSolicitacao = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeSolicitada = table.Column<int>(type: "int", nullable: false),
                    DepartamentoSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSolicitada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevisaoEntregaProduto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDoProduto = table.Column<int>(type: "int", nullable: false),
                    ValorUnitarioDoProduto = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<int>(type: "int", nullable: false),
                    NumeroNotaFiscalProduto = table.Column<long>(type: "bigint", nullable: false),
                    CodigoEAN = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

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
                    QuantidadeTotalEmEstoque = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoDoServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrazoEntregaPadrao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    NomeEmpresaFornecedora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacoesServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacoesServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacoesServico_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitacoesServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FornecedorId",
                table: "Servicos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesServico_FornecedorId",
                table: "SolicitacoesServico",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesServico_ServicoId",
                table: "SolicitacoesServico",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "SolicitacoesServico");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
