using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Dominio.Entity.MetaData
{
    public interface ICondicionIva
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [Index("Index_CondicionIva_Codigo", IsUnique = true)]
        long Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        [Index("Index_CondicionIva_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }


        bool Eliminado { get; set; }
    }
}
