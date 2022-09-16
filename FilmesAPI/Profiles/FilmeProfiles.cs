using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfiles : Profile
    {
        public FilmeProfiles()
        {
            CreateMap<CreateFilmeDto, FilmeModel>();
            CreateMap<UpdateFilmeDto, FilmeModel>();
            CreateMap<FilmeModel, ReadFilmeDto>();
        }
    }
}
