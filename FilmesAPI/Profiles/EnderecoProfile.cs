using AutoMapper;
using FilmesAPI.Data.Dto.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, EnderecoModel>();
            CreateMap<UpdateEnderecoDto, EnderecoModel>();
            CreateMap<EnderecoModel, ReadEnderecoDto>();
        }
    }
}
