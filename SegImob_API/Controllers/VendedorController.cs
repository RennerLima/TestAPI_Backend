using SegImob_API.Business;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using System.Collections.Generic;
using System.Web.Http;

namespace SegImob_API.Controllers
{
    public class VendedorController : ApiController
    {
        [HttpGet]
        [Route("Vendedor")]
        public List<Vendedor> Listar()
        {
            using (var vendedorApp = new VendedorApp())
            {
                return vendedorApp.Listar();
            }
        }


        [HttpPost]
        [Route("Vendedor/Inserir")]
        public Vendedor Inserir([FromBody]Vendedor novoVendedor)
        {
            using (var vendedorApp = new VendedorApp())
            {
                return vendedorApp.Inserir(novoVendedor);
            }
        }

        [HttpGet]
        [Route("Vendedor/VendedorPorId/{vendedorId}")]
        public Vendedor vendedorPorI(int vendedorId)
        {
            using (var vendedorApp = new VendedorApp())
            {
                return vendedorApp.vendedorPorId(vendedorId);
            }
        }

        [HttpDelete]
        [Route("Vendedor/Deletar/{delVendedor}")]
        public void Deletar(int delVendedor)
        {
            using (var vendedorApp = new VendedorApp())
            {
                vendedorApp.Deletar(delVendedor);
            }
        }
    }
}