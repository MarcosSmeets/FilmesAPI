using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto PostFilme(CreateFilmeDto filmeDto)
        {
            FilmeModel filme = _mapper.Map<FilmeModel>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> GetFilmes(int ? classificacaoEtaria)
        {
            List<FilmeModel> filmes;
            if(classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context
                    .Filmes.Where(filmes => filmes.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if(filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }
            return null;
        }

        public ReadFilmeDto GetFilmeById(int id)
        {
            FilmeModel filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }

        public Result PutFilme(int id, UpdateFilmeDto filmeDto)
        {
            FilmeModel filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return Result.Fail("Not Found");

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteFilme(int id)
        {
            FilmeModel filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return Result.Fail("Not Found");

            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
