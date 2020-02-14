using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.Fecha.DTOs
{
    public class FechaDto : DtoBase
    {
        public DateTime FechaEvento { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraCierre { get; set; }

    }
}