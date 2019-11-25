using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.Fecha.DTOs
{
    public class FechaDto : DtoBase
    {
        public DateTime FechaInicio { get; set; }

        public DateTime FechaCierre { get; set; }
    }
}