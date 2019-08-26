using SegImob_API.Database;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SegImob_API.Business
{
    public class ProdutoApp : IDisposable
    {
        private EstudoContext dbEstudo;

        public ProdutoApp()
        {
            dbEstudo = new EstudoContext();
        }

        #region "Metodos"

        public List<Produto> Listar()
        {
            return dbEstudo.Produtos.ToList();
        }

        public Produto Inserir(Produto novoProduto)
        {
            var produto = dbEstudo.Produtos.Add(novoProduto);

            dbEstudo.SaveChanges();
            return produto;
        }

        public Produto Modificar(Produto modificarProduto)
        {
            var prod = dbEstudo.Produtos.Attach(modificarProduto);
            dbEstudo.Entry<Produto>(modificarProduto).State = EntityState.Modified;
            dbEstudo.SaveChanges();

            return prod;
        }

        public List<Produto> Filtrar(ProdutoCriteria produtoCriteria)
        {
            var query = dbEstudo.Produtos.AsQueryable();

            if (produtoCriteria.FlagAtivo.HasValue)
                query = query.Where(x => x.FlagAtivo == produtoCriteria.FlagAtivo.Value);

            if(!String.IsNullOrEmpty(produtoCriteria.Nome))
                query = query.Where(x => x.ProdutoNome.Contains(produtoCriteria.Nome));

            if (produtoCriteria.Id.HasValue)
                query = query.Where(x => x.Id == produtoCriteria.Id);

            return query.ToList();
        }

        public Produto ProdutoPorId(int produtoId)
        {
            int ID = Convert.ToInt32(produtoId);

            var produto = dbEstudo.Produtos.FirstOrDefault(x => x.Id == ID);

            return produto;

        }

        public void Deletar(int produtoId)
        {
            var produto = ProdutoPorId(produtoId);

            dbEstudo.Produtos.Remove(produto);

            dbEstudo.SaveChanges();
        }

        #endregion

        #region "Auxiliares"

        public void Dispose()
        {
            dbEstudo.Dispose();
        }

        #endregion
    }
}