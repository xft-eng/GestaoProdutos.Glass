using AutoMapper;
using Desafio.Glass.Application.Model;
using Desafio.Glass.Application.Model.Input;
using Desafio.Glass.Domain.DTO.DesafioGlass;

namespace Desafio.Glass.Application.AutoMapperConfigs
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ConsultaProdutoModel, Produto>();
            CreateMap<ProdutoModel, Produto>();
        }
    }
}
