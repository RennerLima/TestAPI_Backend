using AutoMapper;
using SegImob_API.Business;
using SegImob_API.Models;
using SegImob_API.Models.Criteria;
using SegImob_API.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace SegImob_API.Controllers
{
    public class VendaController : ApiController
    {
        [HttpGet]
        [Route("Venda")]
        public List<Venda> Listar()
        {
            using (var vendaApp = new VendaApp())
            {
                return vendaApp.Listar();
            }
        }

        [HttpPost]
        [Route("Venda/Inserir")]
        public Venda Inserir([FromBody]Venda novaVenda)
        {
            using (var vendaApp = new VendaApp())
            {
                return vendaApp.Inserir(novaVenda);
            }
        }

        [HttpGet]
        [Route("Venda/VendaPorId/{vendaId}")]
        public Venda vendaPorId(int vendaId)
        {
            using (var vendaApp = new VendaApp())
            {
                return vendaApp.vendaPorId(vendaId);
            }
        }

        [HttpDelete]
        [Route("Venda/Deletar/{delVenda}")]
        public void Deletar(int delVenda)
        {
            using (var vendaApp = new VendaApp())
            {
                vendaApp.Deletar(delVenda);
            }
        }

        [HttpGet]
        [Route("Venda/VendasDoDia")]
        public List<VendaViewModel> VendasDoDia([FromUri] VendaCriteria vendaCriteria)
        {
            if (vendaCriteria == null)
                vendaCriteria = new VendaCriteria();

            using (var vendaApp = new VendaApp())
            {
                return Mapper.Map<List<VendaViewModel>>(vendaApp.VendasDoDia(vendaCriteria));
            }
        }
    }
}