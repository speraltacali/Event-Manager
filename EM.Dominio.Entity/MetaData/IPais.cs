using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IPais
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Pais_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string FileName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Path { get; set; }
    }
}