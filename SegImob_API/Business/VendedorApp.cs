using SegImob_API.Database;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegImob_API.Business
{
    public class VendedorApp : IDisposable
    {
        private EstudoContext dbEstudo;

        public VendedorApp()
        {
            dbEstudo = new EstudoContext();
        }

        public List<Vendedor> Listar()
        {
            return dbEstudo.Vendedores.ToList();
        }

        public Vendedor Inserir(Vendedor novoVendedor)
        {
            var vendedor = dbEstudo.Vendedores.Add(novoVendedor);

            dbEstudo.SaveChanges();
            return vendedor;
        }

        public Vendedor vendedorPorId(int vendedorId)
        {
            int ID = Convert.ToInt32(vendedorId);

            var vendedor = dbEstudo.Vendedores.FirstOrDefault(x => x.Id == ID);

            return vendedor;

        }

        public void Deletar(int vendedorId)
        {
            var vendedor = vendedorPorId(vendedorId);

            dbEstudo.Vendedores.Remove(vendedor);

            dbEstudo.SaveChanges();
        }

        public void Dispose()
        {
            dbEstudo.Dispose();
        }
    }
}