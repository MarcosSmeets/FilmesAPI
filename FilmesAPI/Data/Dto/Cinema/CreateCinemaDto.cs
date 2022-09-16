using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto.Cinema
{
    public class CreateCinemaDto
    {
        [Required]
        public string Cinemas { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
