using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventoAPI.Models
{
    public class Organizador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del organizador es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El cargo del organizador es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El cargo debe tener entre 3 y 50 caracteres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "El evento asociado es obligatorio")]
        [ForeignKey("Evento")]
        public int EventoId { get; set; }

        [JsonIgnore]
        public Evento? Evento { get; set; }
    }
}
