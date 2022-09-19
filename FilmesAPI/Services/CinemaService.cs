using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Cinema;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadCinemaDto> GetCinemas(string nomeDoFilme)
        {
            List<CinemaModel> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<CinemaModel> query = from cinema in cinemas
                                                 where cinema.Sessoes.Any
                                                (sessao => sessao.Filme.Titulo == nomeDoFilme)
                                                 select cinema;
                cinemas = query.ToList();
            }
            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto PostCinema(CreateCinemaDto cinemaDto)
        {
            CinemaModel cinema = _mapper.Map<CinemaModel>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public ReadCinemaDto GetCinemaById(int id)
        {
            CinemaModel cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto filmeDto = _mapper.Map<ReadCinemaDto>(cinema);
                return filmeDto;
            }
            return null;
        }

        public Result DeleteCinema(int id)
        {
            CinemaModel cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return Result.Fail("Not Found");

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result PutCinema(int id, UpdateCinemaDto cinemaDto)
        {
            CinemaModel cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                Result.Fail("Not Found");

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
