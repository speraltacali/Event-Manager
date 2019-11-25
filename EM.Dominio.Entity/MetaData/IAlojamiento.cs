using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IAlojamiento
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long LugarId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Alojamiento_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }
    }
}