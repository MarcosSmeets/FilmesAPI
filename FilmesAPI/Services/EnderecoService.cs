using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Endereco;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto PostEndereco(CreateEnderecoDto enderecoDto)
        {
            EnderecoModel endereco = _mapper.Map<EnderecoModel>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> GetEndereco()
        {
            List<EnderecoModel> enderecos = _context.Enderecos.ToList();
            if(enderecos == null)
                return null;
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        public ReadEnderecoDto GetEnderecoById(int id)
        {
            EnderecoModel endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
            }
            return null;
        }

        public Result PutEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            EnderecoModel endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return Result.Fail("Not Found");

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteEndereco(int id)
        {
            EnderecoModel endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return Result.Fail("Not Found");

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
