using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegImob_API.Models.Criteria
{
    public class VendaCriteria
    {
        public int? Id_Vendedor { get; set; }
        public int? Id_Produto { get; set; }
        public decimal? ValorComissaoVenda { get; set; }
        public DateTime? DataVendaInicial { get; set; }
        public DateTime? DataVendaFinal { get; set; }
    }
}