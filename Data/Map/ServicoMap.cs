//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using TesteUGB.Models;

//namespace TesteUGB.Data.Map
//{
//    public class ServicoMap : IEntityTypeConfiguration<ServicoModel>
//    {
//        public void Configure(EntityTypeBuilder<ServicoModel> builder)
//        {
//            builder.HasKey(x => x.Id);

//            builder.HasOne(x => x.Fornecedor)
//                .WithMany(p => p.Servicos)
//                .HasForeignKey(x => x.FornecedorId);
//        }
//    }
//}