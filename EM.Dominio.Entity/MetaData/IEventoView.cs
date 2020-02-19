using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Dominio.Entity.MetaData
{
    public interface IEventoView
    {
        string Titulo { get; set; }

        string Orante { get; set; }

        string Organizacion { get; set; }

        string Descripcion { get; set; }

        string Mail { get; set; }

        string Latitud { get; set; }

        string Longitud { get; set; }

        long TipoEventoId { get; set; }

        byte[] Imagen { get; set; }

        string Telefono { get; set; }

        decimal Precio { get; set; }

        long EntradaId { get; set; }

        DateTime FechaEvento { get; set; }

        DateTime HoraInicio { get; set; }

        DateTime HoraFin { get; set; }


        string DomicilioCompleto { get; set; }
    }
}
