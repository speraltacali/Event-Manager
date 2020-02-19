using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Dominio.Entity.MetaData
{
    public interface IUsuarioView
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(15, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Cuil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(60, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato Incorrecto")]
        string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        DateTime FechaNacimiento { get; set; }

        //******************************************//


        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string User { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string PasswordRep { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaCreacion { get; set; }
    }
}
