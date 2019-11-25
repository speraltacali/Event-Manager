using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.FechaEvento.DTOs
{
    public class FechaEventoDto : DtoBase
    {
        public long EventosId { get; set; }

        public long FechaId { get; set; }
    }
}