using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Dominio.Entity.MetaData
{
    public interface ICreadorEvento
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        long EventoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        long UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        DateTime Fecha { get; set; }
    }
}
