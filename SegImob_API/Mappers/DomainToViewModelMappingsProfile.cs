using AutoMapper;
using SegImob_API.Models;
using SegImob_API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegImob_API.Mappers
{
    public class DomainToViewModelMappingsProfile : Profile
    {
        public override string ProfileName
        {
             get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingsProfile()
        {
            this.CreateMap<Venda, VendaViewModel>()
                .ForMember(vm => vm.NomeProduto, map => map.MapFrom(m => m.Produto != null ? m.Produto.ProdutoNome : string.Empty))
                .ForMember(vm => vm.NomeVendedor, map => map.MapFrom(m => m.Vendedor != null ? m.Vendedor.Nome : string.Empty));
        }

    }
}