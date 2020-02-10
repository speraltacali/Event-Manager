using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Lugar.DTOs
{
    public class LugarDto : DtoBase
    {
        public string Descripcion { get; set; }

        public long DomicilioId { get; set; }
    }
}