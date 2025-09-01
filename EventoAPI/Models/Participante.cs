using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventoAPI.Models
{
    public class Participante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del participante es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "El evento asociado es obligatorio")]
        [ForeignKey("Evento")]
        public int EventoId { get; set; }

        [JsonIgnore]
        public Evento? Evento { get; set; }
    }
}
