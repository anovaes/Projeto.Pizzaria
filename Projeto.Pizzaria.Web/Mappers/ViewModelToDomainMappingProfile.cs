using AutoMapper;
using Projeto.Pizzaria.Dao.Entidade;
using Projeto.Pizzaria.Web.Models;

namespace Projeto.Pizzaria.Web.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<CategoriaProdutoModel, CategoriaProduto>();
            CreateMap<ProdutoModel, Produto>();
        }
    }
}