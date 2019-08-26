using SegImob_API.Database;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace SegImob_API.Business
{
    public class VendaApp : IDisposable
    {
        private EstudoContext dbEstudo;

        public VendaApp()
        {
            dbEstudo = new EstudoContext();
        }

        public Venda Inserir(Venda novaVenda)
        {
            //BUSCo a entidade completa de vendedor e produto
            Produto produto = dbEstudo.Produtos.FirstOrDefault(x => x.Id == novaVenda.Id_Produto);
            Vendedor vendedor = dbEstudo.Vendedores.FirstOrDefault(x => x.Id == novaVenda.Id_Vendedor);

            //Testo para garantir que foi encontrado as entidades
            if (produto == null || vendedor == null)
                throw new Exception("Erro ao encontrar Vendedor ou Produto");

            //realiza logica de campos computaveis
            novaVenda.ValorComissaoVenda = (novaVenda.QuantidadeItens * produto.ProdutoPreco) * (vendedor.Comissao / 100);
            novaVenda.ValorTotal = (novaVenda.QuantidadeItens * produto.ProdutoPreco);

            var venda = dbEstudo.Vendas.Add(novaVenda);

            dbEstudo.SaveChanges();
            return venda;
        }

        public List<Venda> Listar()
        {
            return dbEstudo.Vendas.ToList();
        }

        public List<Venda> VendasDoDia(VendaCriteria vendaCriteria)
        {
            var query = dbEstudo.Vendas
                                .Include(x => x.Produto)
                                .Include(x => x.Vendedor);

            if (vendaCriteria.DataVendaInicial.HasValue && !vendaCriteria.DataVendaFinal.HasValue)
                query = query.Where(x => x.DataVenda >= vendaCriteria.DataVendaInicial);
            else if (!vendaCriteria.DataVendaInicial.HasValue && vendaCriteria.DataVendaFinal.HasValue)
                query = query.Where(x => x.DataVenda <= vendaCriteria.DataVendaFinal);
            else if (vendaCriteria.DataVendaInicial.HasValue && vendaCriteria.DataVendaFinal.HasValue)
                query = query.Where(x => x.DataVenda >= vendaCriteria.DataVendaInicial
                && x.DataVenda <= vendaCriteria.DataVendaFinal);

            if (vendaCriteria.Id_Vendedor.HasValue)
                query = query.Where(x => x.Id_Vendedor == vendaCriteria.Id_Vendedor);

            if (vendaCriteria.Id_Produto.HasValue)
                query = query.Where(x => x.Id_Produto == vendaCriteria.Id_Produto);

            return query.ToList();
        }

        public Venda vendaPorId(int vendaId)
        {
            int ID = Convert.ToInt32(vendaId);

            var venda = dbEstudo.Vendas.FirstOrDefault(x => x.Id == ID);

            return venda;

        }

        public void Deletar(int vendaId)
        {
            var venda = vendaPorId(vendaId);

            dbEstudo.Vendas.Remove(venda);

            dbEstudo.SaveChanges();
        }

        public void Dispose()
        {
            dbEstudo.Dispose();
        }
    }
}