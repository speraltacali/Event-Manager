using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Domicilio.DTOs
{
    public class DomicilioDto : DtoBase
    {
        public long LocalidadId { get; set; }

        public string Descripción { get; set; }
    }
}