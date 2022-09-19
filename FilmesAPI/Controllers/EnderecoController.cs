using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Endereco;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult PostEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.PostEndereco(enderecoDto);
            return CreatedAtAction(nameof(GetEnderecoById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetEndereco()
        {
            List<ReadEnderecoDto> readDto = _enderecoService.GetEndereco();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnderecoById(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.GetEnderecoById(id);
            if (readDto != null)
                return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoService.PutEndereco(id, enderecoDto);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Result result = _enderecoService.DeleteEndereco(id);
            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

    }
}
