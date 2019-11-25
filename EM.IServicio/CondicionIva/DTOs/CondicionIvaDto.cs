using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.IServicio.CondicionIva.DTOs
{
    public class CondicionIvaDto
    {
        public long Id { get; set; }

        public long Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}
