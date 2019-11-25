using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IEntrada
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaHasta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long EventoId { get; set; }
    }
}