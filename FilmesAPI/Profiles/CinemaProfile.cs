using AutoMapper;
using FilmesAPI.Data.Dto.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, CinemaModel>();
            CreateMap<UpdateCinemaDto, CinemaModel>();
            CreateMap<CinemaModel, ReadCinemaDto>();
        }
    }
}
