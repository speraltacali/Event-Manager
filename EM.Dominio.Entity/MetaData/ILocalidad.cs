using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface ILocalidad
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long ProvinciaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Localidad_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }
    }
}