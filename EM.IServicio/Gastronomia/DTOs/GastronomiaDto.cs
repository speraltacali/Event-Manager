using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Gastronomia.DTOs
{
    public class GastronomiaDto : DtoBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }
    }
}