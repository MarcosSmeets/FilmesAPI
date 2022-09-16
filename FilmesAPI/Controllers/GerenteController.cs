using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Gerente;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller}")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostGerente(CreateGerenteDto gerenteDto)
        {
            GerenteModel gerente = _mapper.Map<GerenteModel>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGerenteById), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult GetGerenteById(int id)
        {
            GerenteModel gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto filmeDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerente);
            }
            return NotFound();
        }
    }
}
