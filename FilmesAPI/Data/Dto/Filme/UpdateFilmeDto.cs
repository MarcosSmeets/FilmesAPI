using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dto
{
    public class UpdateFilmeDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        [StringLength(30)]
        public string Genero { get; set; }
        [Range(1, 600)]
        public int Duracao { get; set; }
    }
}
