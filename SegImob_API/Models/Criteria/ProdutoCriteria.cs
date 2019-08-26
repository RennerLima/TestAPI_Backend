using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegImob_API.Models.Criteria
{
    public class ProdutoCriteria
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public bool? FlagAtivo { get; set; }
    }
}