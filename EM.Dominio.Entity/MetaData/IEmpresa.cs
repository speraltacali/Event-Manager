using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.MetaData
{
    public interface IEmpresa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Empresa_Cuil", IsUnique = true)]
        string Cuil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Empresa_NombreFantasia", IsUnique = true)]
        string NombreFantasia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Empresa_RazonSocial", IsUnique = true)]
        string RazonSocial { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(1000, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Empresa_Domicilio", IsUnique = true)]
        string Domicilio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [Index("Index_Empresa_Telefono", IsUnique = true)]
        string Telefono { get; set; }
    }
}