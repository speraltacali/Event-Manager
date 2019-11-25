using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.PersonaEvento.DTOs
{
    public class PersonaEventoDto : DtoBase
    {
        public long PersonaId { get; set; }

        public long EventoId { get; set; }

        public DateTime Fecha { get; set; }

        public long EstadoId { get; set; }
    }
}