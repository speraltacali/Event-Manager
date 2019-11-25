using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Alojamiento.DTOs
{
    public class AlojamientoDto : DtoBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }
    }
}