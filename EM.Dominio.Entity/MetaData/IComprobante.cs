using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Index("Index_Comprobante_Numero", IsUnique = true)]
        long Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        decimal SubTotal { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        decimal Total { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        decimal Descuento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long TipoComprobanteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long FormaPagoId { get; set; }
    }
}