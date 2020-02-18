using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Dominio.Entity.MetaData
{
    public interface ITarjetaDebito
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        string NombreTitular { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        string Tarjeta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        string Mes { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        string Año { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        string CCV { get; set; }
    }
}
