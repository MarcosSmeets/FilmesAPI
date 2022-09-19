using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Gerente;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto PostGerente(CreateGerenteDto gerenteDto)
        {
            GerenteModel gerente = _mapper.Map<GerenteModel>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> GetGerente()
        {
            List<GerenteModel> gerentes = _context.Gerentes.ToList();
            if (gerentes == null)
                return null;
            return _mapper.Map<List<ReadGerenteDto>>(gerentes);
        }

        public ReadGerenteDto GetGerenteById(int id)
        {
            GerenteModel gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }
            return null;
        }

        public Result PutGerente(int id, UpdateGerenteDto gerenteDto)
        {
            GerenteModel gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return Result.Fail("Not Found");

            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteGerente(int id)
        {
            GerenteModel gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return Result.Fail("Not Found");

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
