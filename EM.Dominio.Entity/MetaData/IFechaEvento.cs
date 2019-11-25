using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IFechaEvento
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long EventosId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long FechaId { get; set; }
    }
}