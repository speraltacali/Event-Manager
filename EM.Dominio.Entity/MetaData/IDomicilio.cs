using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IDomicilio
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long LocalidadId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Domicilio_Descripcion", IsUnique = true)]
        string Descripción { get; set; }
    }
}