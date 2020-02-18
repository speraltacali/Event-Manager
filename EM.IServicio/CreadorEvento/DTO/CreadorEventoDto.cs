using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.CreadorEvento.DTO
{
    public class CreadorEventoDto :DtoBase
    {
        public long EventoId { get; set; }

        public long UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

    }
}
