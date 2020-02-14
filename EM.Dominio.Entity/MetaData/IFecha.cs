using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IFecha
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaEvento { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime HoraCierre { get; set; }
    }
}