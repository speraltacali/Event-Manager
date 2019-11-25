using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Transporte.DTOs
{
    public class TransporteDto : DtoBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }
    }
}