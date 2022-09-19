using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller}")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult PostGerente(CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _gerenteService.PostGerente(gerenteDto);
            return CreatedAtAction(nameof(GetGerenteById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetGerente()
        {
            List<ReadGerenteDto> readDto = _gerenteService.GetGerente();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetGerenteById(int id)
        {
            ReadGerenteDto readDto = _gerenteService.GetGerenteById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult PutGerente(int id,[FromBody] UpdateGerenteDto gerenteDto)
        {
            Result result = _gerenteService.PutGerente(id, gerenteDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            Result result = _gerenteService.DeleteGerente(id);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
