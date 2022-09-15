using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto.Cinema
{
    public class UpdateCinemaDto
    {
        [Required]
        public string Cinemas { get; set; }
    }
}
