using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.Fecha.DTOs
{
    public class FechaDto : DtoBase
    {
        public DateTime FechaInicio { get; set; }

        public DateTime FechaCierre { get; set; }


        //Utilizamos el dto para poder tambien insertar en la clase FechaEvento -- Todo en FechaServicio
        public long EventoId { get; set; }
    }
}