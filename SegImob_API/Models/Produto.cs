using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SegImob_API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string ProdutoNome { get; set; }
        public Decimal ProdutoPreco { get; set; }
        public bool FlagAtivo { get; set; }
    }
}