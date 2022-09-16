using AutoMapper;
using FilmesAPI.Data.Dto.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, GerenteModel>();
            CreateMap<UpdateGerenteDto, GerenteModel>();
            CreateMap<GerenteModel, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas,
                opts => opts.MapFrom(gerente => gerente.Cinema.Select(c => new { c.Id, c.Cinemas, c.Endereco, c.EnderecoId })));
        }
    }
}
