using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class FilmeModel
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        [StringLength(30)]
        public string Genero { get; set; }
        [Range(1,600)]
        public int Duracao { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual List<SessaoModel> Sessoes { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
