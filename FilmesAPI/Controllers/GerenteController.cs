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

        [HttpGet]
        public IActionResult GetGerente()
        {
            return Ok(_context.Gerentes);
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
        
        [HttpPut("{id}")]
        public IActionResult PutGerente(int id,[FromBody] UpdateGerenteDto gerenteDto)
        {
            GerenteModel gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return NotFound();

            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            GerenteModel gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return NotFound();

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
