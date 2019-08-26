using SegImob_API.Database.Configuration;
using SegImob_API.Models;
using System.Data.Entity;

namespace SegImob_API.Database
{
    public class EstudoContext : DbContext
    {
        public EstudoContext() : base("name=cnnEstudo")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new EquipeConfiguration());
            modelBuilder.Configurations.Add(new VendaConfiguration());
            modelBuilder.Configurations.Add(new VendedorConfiguration());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}