using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class CinemaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Cinemas { get; set; }
        public virtual EnderecoModel Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual GerenteModel Gerente { get; set; }
        public int GerenteId { get; set; }
        [JsonIgnore]
        public virtual List<SessaoModel> Sessoes { get; set; }
    }
}
