using FilmesAPI.Models;

namespace FilmesAPI.Data.Dto.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public CinemaModel Cinema { get; set; }
        public FilmeModel Filme { get; set; }
        public DateTime HoraDaSessao { get; set; }
        public DateTime PreviaDeEncerramento { get; set; }
    }
}
