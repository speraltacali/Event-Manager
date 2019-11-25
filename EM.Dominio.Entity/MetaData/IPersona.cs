using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IPersona
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(15, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Persona_Cuil", IsUnique = true)]
        string Cuil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(60, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Persona_Mail", IsUnique = true)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato Incorrecto")]
        string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_Persona_Telefono", IsUnique = true)]
        string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        DateTime FechaNacimiento { get; set; }

    }
}