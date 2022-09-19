using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult PostFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto =  _filmeService.PostFilme(filmeDto);

            return CreatedAtAction(nameof(GetFilmeById), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult GetFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto =  _filmeService.GetFilmes( classificacaoEtaria);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            ReadFilmeDto readDto = _filmeService.GetFilmeById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.PutFilme(id, filmeDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Result result = _filmeService.DeleteFilme(id);
            if(result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
