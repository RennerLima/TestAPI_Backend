using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SegImob_API.Models.ViewModels
{
    public class VendaViewModel
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public int QuantidadeItens { get; set; }
        public int Id_Vendedor { get; set; }
        public int Id_Produto { get; set; }
        public decimal ValorComissaoVenda { get; set; }
        public decimal ValorTotal { get; set; }


        #region "Propriedade Estrangeiras"

        public string NomeProduto{ get; set; }
        public string NomeVendedor { get; set; }

        #endregion

    }
}

