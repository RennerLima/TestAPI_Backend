using SegImob_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SegImob_API.Database.Configuration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {

            ToTable("TBL_PRODUTO");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProdutoNome).HasColumnName("NM_PRODUTO").HasMaxLength(100).IsRequired();
            Property(x => x.ProdutoPreco).HasColumnName("VL_PRECO").IsRequired();
            Property(x => x.FlagAtivo).HasColumnName("FL_ATIVO").IsRequired();

        }
    }
}