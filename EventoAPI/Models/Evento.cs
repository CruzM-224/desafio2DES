using System.ComponentModel.DataAnnotations;

namespace EventoAPI.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del evento es obligatorio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha del evento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El lugar del evento es obligatorio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El lugar debe tener entre 5 y 100 caracteres")]
        public string Lugar { get; set; }

        public ICollection<Participante> Participantes { get; set; }
        public ICollection<Organizador> Organizadores { get; set; }
    }
}
