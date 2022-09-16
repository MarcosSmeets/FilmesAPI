using AutoMapper;
using FilmesAPI.Data.Dto.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, SessaoModel>();
            CreateMap<UpdateSessaoDto, SessaoModel>();
            CreateMap<SessaoModel, ReadSessaoDto>()
                .ForMember(dto => dto.PreviaDeEncerramento,
                opts => opts.MapFrom(dto => dto.HoraDaSessao.AddMinutes(dto.Filme.Duracao)));
        }
    }
}
