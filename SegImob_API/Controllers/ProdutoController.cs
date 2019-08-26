using SegImob_API.Business;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using System.Collections.Generic;
using System.Web.Http;

namespace SegImob_API.Controllers
{
    public class ProdutoController : ApiController
    {

        [HttpGet]
        [Route("Produto")]
        public List<Produto> Listar()
        {
            using (var produtoApp = new ProdutoApp())
            {
                return produtoApp.Listar();
            }
        }

        [HttpGet]
        [Route("Produto/Filtrar")]
        public List<Produto> Filtrar([FromUri] ProdutoCriteria produtoCriteria)
        {

            if (produtoCriteria == null)
                produtoCriteria = new ProdutoCriteria();

            using (var produtoApp = new ProdutoApp())
            {
                return produtoApp.Filtrar(produtoCriteria);
            }
        }

        [HttpPut]
        [Route("Produto/Modificar")]
        public Produto Modificar([FromBody]Produto modificarProduto)
        {
            using (var produtoApp = new ProdutoApp())
            {
                return produtoApp.Modificar(modificarProduto);
            }
        }

        [HttpPost]
        [Route("Produto/Inserir")]
        public Produto Inserir([FromBody]Produto novoProduto)
        {
            using (var produtoApp = new ProdutoApp())
            {
                return produtoApp.Inserir(novoProduto);
            }
        }

        [HttpGet]
        [Route("Produto/ProdutoPorId/{produtoId}")]
        public Produto FiltroId(int produtoId)
        {
            using (var produtoApp = new ProdutoApp())
            {
                return produtoApp.ProdutoPorId(produtoId);
            }
        }

        [HttpDelete]
        [Route("Produto/Deletar/{delProduto}")]
        public void Deletar(int delProduto)
        {
            using (var produtoApp = new ProdutoApp())
            {
                produtoApp.Deletar(delProduto);
            }
        }
    }
}
