using SegImob_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SegImob_API.Database.Configuration
{
    public class VendaConfiguration : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguration()
        {
            ToTable("TBL_VENDA");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DataVenda).HasColumnName("DT_VENDA").IsRequired();
            Property(x => x.QuantidadeItens).HasColumnName("QT_ITENS").IsRequired();
            Property(x => x.Id_Vendedor).HasColumnName("ID_VENDEDOR").IsRequired();
            Property(x => x.Id_Produto).HasColumnName("ID_PRODUTO").IsRequired();
            Property(x => x.ValorComissaoVenda).HasColumnName("VL_COMISSAO_VENDA").IsRequired();
            Property(x => x.ValorTotal).HasColumnName("VL_TOTAL").IsRequired();

            HasRequired(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.Id_Produto);

            HasRequired(x => x.Vendedor)
                .WithMany()
                .HasForeignKey(x => x.Id_Vendedor);


        }
    }
}