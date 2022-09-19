using AutoMapper;
using FilmesAPI.Data.Dto.Cinema;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult GetCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> cinemaDto = _cinemaService.GetCinemas(nomeDoFilme);
            return Ok(cinemaDto);
        }

        [HttpPost]
        public IActionResult PostCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.PostCinema(cinemaDto);
            return CreatedAtAction(nameof(GetCinemaById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaById(int id)
        {
            ReadCinemaDto readDto = _cinemaService.GetCinemaById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.PutCinema(id, cinemaDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Result result = _cinemaService.DeleteCinema(id);
            if(result.IsFailed) 
                return NotFound();
            return NoContent();
        }
    }
}
