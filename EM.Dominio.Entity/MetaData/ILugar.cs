using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface ILugar
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        long PaisId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Lugar_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }
    }
}