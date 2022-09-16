namespace FilmesAPI.Data.Dto.Sessao
{
    public class UpdateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HoraDaSessao { get; set; }
    }
}
