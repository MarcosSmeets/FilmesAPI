using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto.Gerente
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
