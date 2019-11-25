using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IFecha
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaCierre { get; set; }
    }
}