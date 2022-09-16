using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Sessao;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        
        [HttpPost]
        public IActionResult PostSessao(CreateSessaoDto dto)
        {
            SessaoModel sessao = _mapper.Map<SessaoModel>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessaoById), new { Id = sessao.Id, sessao });
        }

        [HttpGet]
        public IActionResult GetSessao()
        {
            return Ok(_context.Sessoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessaoById(int id)
        {
            SessaoModel sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto SessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(SessaoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            SessaoModel sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
                return NotFound();

            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao(int id)
        {
            SessaoModel sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
                return NotFound();

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
