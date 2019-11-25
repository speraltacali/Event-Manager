using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.Entrada.DTOs
{
    public class EntradaDto : DtoBase
    {
        public decimal Monto { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public int Cantidad { get; set; }

        public long EventoId { get; set; }
    }
}