using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.EventoLugar.DTOs
{
    public class EventoLugarDto : DtoBase
    {
        public long EventoId { get; set; }

        public long LugarId { get; set; }
    }
}