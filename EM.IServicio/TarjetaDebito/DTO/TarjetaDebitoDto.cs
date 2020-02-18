using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.IServicio.TarjetaDebito.DTO
{
    [MetadataType(typeof(Dominio.Entity.MetaData.ITarjetaDebito))]
    public class TarjetaDebitoDto
    {
        public string NombreTitular { get; set; }

        public string Tarjeta { get; set; }

        public string Mes { get; set; }

        public string Año { get; set; }

        public string CCV { get; set; }

        public long ComprobanteId { get; set; }
    }
}
