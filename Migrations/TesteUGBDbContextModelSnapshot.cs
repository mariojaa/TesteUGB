﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteUGB.Data;

#nullable disable

namespace TesteUGB.Migrations
{
    [DbContext(typeof(TesteUGBDbContext))]
    partial class TesteUGBDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DescricaoDoServico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDoServico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEmpresaFornecedora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PrazoEntregaPadrao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("SolicitacaoServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("ServicoId");

                    b.ToTable("SolicitacoesServico");
                });

            modelBuilder.Entity("TesteUGB.Models.ComprasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoDaSolicitacao")
                        .HasColumnType("int");

                    b.Property<long>("CodigoEAN")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataPrevisaoEntregaProduto")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSolicitada")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartamentoSolicitante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroNotaFiscalProduto")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeSolicitada")
                        .HasColumnType("int");

                    b.Property<int>("TipoDoProduto")
                        .HasColumnType("int");

                    b.Property<int>("ValorTotal")
                        .HasColumnType("int");

                    b.Property<int>("ValorUnitarioDoProduto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("TesteUGB.Models.EstoqueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("CodigoEAN")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCadastroProduto")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroNotaFiscalProduto")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeMinimaEmEstoque")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeTotalEmEstoque")
                        .HasColumnType("int");

                    b.Property<string>("SetorDeDeposito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDoProdutoUnitarioOuPacote")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("TesteUGB.Models.FornecedorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BairroEnderecoFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CNPJFornecedor")
                        .HasColumnType("bigint");

                    b.Property<string>("CidadeEnderecoFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoEnderecoFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InscricaoEstadualEMunicipalFornecedor")
                        .HasColumnType("bigint");

                    b.Property<string>("NomeEmpresaFornecedora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroEnderecoFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("PaisEnderecoFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("TesteUGB.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartamentoFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatriculaUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompletoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ServicoModel", b =>
                {
                    b.HasOne("TesteUGB.Models.FornecedorModel", "Fornecedor")
                        .WithMany("Servicos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("SolicitacaoServicoModel", b =>
                {
                    b.HasOne("TesteUGB.Models.FornecedorModel", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ServicoModel", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("TesteUGB.Models.FornecedorModel", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
