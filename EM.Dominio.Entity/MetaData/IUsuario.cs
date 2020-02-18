using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IUsuario
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Usuario_User", IsUnique = true)]
        string User { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(60, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Usuario_Mail", IsUnique = true)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato Incorrecto")]
        string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaCreacion { get; set; }

    }
}