using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Sessao;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto PostSessao(CreateSessaoDto dto)
        {
            SessaoModel sessao = _mapper.Map<SessaoModel>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto> GetSessao()
        {
            List<SessaoModel> sessoes = _context.Sessoes.ToList();
            if (sessoes == null)
                return null;
            return _mapper.Map<List<ReadSessaoDto>>(sessoes);
        }

        public ReadSessaoDto GetSessaoById(int id)
        {
            SessaoModel sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto SessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return SessaoDto;
            }
            return null;
        }

        public Result PutSessao(int id, UpdateSessaoDto sessaoDto)
        {
            SessaoModel sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
                return Result.Fail("Not Found");

            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteSessao(int id)
        {
            SessaoModel sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
                return Result.Fail("Not Found");

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
