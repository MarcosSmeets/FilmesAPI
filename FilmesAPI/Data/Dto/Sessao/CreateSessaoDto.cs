namespace FilmesAPI.Data.Dto.Sessao
{
    public class CreateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HoraDaSessao { get; set; }
    }
}
