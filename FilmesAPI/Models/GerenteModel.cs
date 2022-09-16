using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class GerenteModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<CinemaModel> Cinema { get; set; }
    }
}
