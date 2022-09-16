using FilmesAPI.Models;

namespace FilmesAPI.Data.Dto.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
