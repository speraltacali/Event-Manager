using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Comprobante.DTOs
{
    public class ComprobanteViewDto : DtoBase
    {
        public long Numero { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        public long EventoId { get; set; }

        public long UsuarioId { get; set; }

        public string NombreTitular { get; set; }

        public string Tarjeta { get; set; }

        public string Mes { get; set; }

        public string Año { get; set; }

        public string CCV { get; set; }

        public long ComprobanteId { get; set; }
    }
}
