using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IComprobanteFactura
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long IncripcionCuentaId { get; set; }
    }
}