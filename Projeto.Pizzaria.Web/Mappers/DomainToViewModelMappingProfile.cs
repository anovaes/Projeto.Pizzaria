using AutoMapper;
using Projeto.Pizzaria.Dao.Entidade;
using Projeto.Pizzaria.Web.Models;

namespace Projeto.Pizzaria.Web.Mappers
{
    public class DomainToViewModelMappingProfile :Profile
    {
        public DomainToViewModelMappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();


            CreateMap<CategoriaProduto, CategoriaProdutoModel>();
            CreateMap<Produto, ProdutoModel>();
        }
    }
}