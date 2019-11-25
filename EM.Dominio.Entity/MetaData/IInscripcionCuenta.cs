using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IInscripcionCuenta
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        Operacion Operacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long EventoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long EntradaId { get; set; }
    }
}