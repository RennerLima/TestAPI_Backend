using SegImob_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SegImob_API.Database.Configuration
{
    public class EquipeConfiguration : EntityTypeConfiguration<Equipe>
    {
        public EquipeConfiguration()
        {
            ToTable("TBL_EQUIPE");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("NM_FUNCIONARIO").HasMaxLength(100).IsRequired();
            Property(x => x.Idade).HasColumnName("NR_IDADE").IsOptional();
            Property(x => x.Sexo).HasColumnName("DS_SEXO").IsOptional();
        }
    }
}