using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IPersonaEvento
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long PersonaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long EventoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        string Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime EstadoId { get; set; }
    }
}