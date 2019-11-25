using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IEvento
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        long EmpresaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        long TipoEventoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Evento_Titulo", IsUnique = true)]
        string Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Evento_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Evento_Mail", IsUnique = true)]
        string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        byte[] Imagen { get; set; }
    }
}