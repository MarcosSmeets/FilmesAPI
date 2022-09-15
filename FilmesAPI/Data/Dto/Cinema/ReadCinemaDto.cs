using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto.Cinema
{
    public class ReadCinemaDto
    {
        [Required]
        public string Cinemas { get; set; }
    }
}
