using SegImob_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SegImob_API.Database.Configuration
{
    public class VendedorConfiguration : EntityTypeConfiguration<Vendedor>
    {
        public VendedorConfiguration()
        {
            ToTable("TBL_VENDEDOR");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("NM_VENDEDOR").HasMaxLength(100).IsRequired();
            Property(x => x.Comissao).HasColumnName("VL_COMISSAO_PADRAO").IsRequired();
            Property(x => x.FlagAtivo).HasColumnName("FL_ATIVO").IsRequired();
        }
    }
}