using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IProvincia
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Provincia_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long PaisId { get; set; }
    }
}