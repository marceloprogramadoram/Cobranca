using AutoMapper;
using Cobranca.Domain.Entities;
using Cobranca.Service.DTO;

namespace Cobranca.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Boleto, BoletoDTO>().ReverseMap();

            CreateMap<Banco, BancoDTO>().ReverseMap();

        }
    }
}
