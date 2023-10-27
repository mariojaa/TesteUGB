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
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}