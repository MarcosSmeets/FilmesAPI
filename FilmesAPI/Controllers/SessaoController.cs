using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        } 
        
        [HttpPost]
        public IActionResult PostSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.PostSessao(dto);
            return CreatedAtAction(nameof(GetSessaoById), new { Id = readDto.Id, readDto });
        }

        [HttpGet]
        public IActionResult GetSessao()
        {
            List<ReadSessaoDto> readDto = _sessaoService.GetSessao();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessaoById(int id)
        {
            ReadSessaoDto readDto = _sessaoService.GetSessaoById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result result = _sessaoService.PutSessao(id, sessaoDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao(int id)
        {
            Result result = _sessaoService.DeleteSessao(id);
            if(result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
