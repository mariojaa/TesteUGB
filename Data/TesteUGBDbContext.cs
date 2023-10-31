using Microsoft.EntityFrameworkCore;
using TesteUGB.Data.Map;
using TesteUGB.Models;

namespace TesteUGB.Data
{
    public class TesteUGBDbContext : DbContext
    {
        public TesteUGBDbContext(DbContextOptions<TesteUGBDbContext> options) : base(options)
        {

        }
        public DbSet<FornecedorModel> Fornecedores { get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ComprasModel> Compras { get; set; }
        public DbSet<SolicitacaoServicoModel> SolicitacoesServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());

            
            modelBuilder.Entity<SolicitacaoServicoModel>()
                .HasOne(s => s.Servico)
                .WithMany()
                .HasForeignKey(s => s.ServicoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SolicitacaoServicoModel>()
                .HasOne(s => s.Fornecedor)
                .WithMany()
                .HasForeignKey(s => s.FornecedorId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
