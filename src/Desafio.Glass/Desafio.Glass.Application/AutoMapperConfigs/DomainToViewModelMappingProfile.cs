using AutoMapper;
using Desafio.Glass.Application.Model;
using Desafio.Glass.Domain.DTO.DesafioGlass;

namespace Desafio.Glass.Application.AutoMapperConfigs
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoModel>();
        }
    }
}
