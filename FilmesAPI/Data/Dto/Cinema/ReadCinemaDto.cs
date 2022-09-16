using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Cinemas { get; set; }
        public EnderecoModel Endereco { get; set; }
        public GerenteModel Gerente { get; set; }

    }
}
