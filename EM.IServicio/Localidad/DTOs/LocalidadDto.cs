using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Localidad.DTOs
{
    public class LocalidadDto : DtoBase
    {
        public long ProvinciaId { get; set; }

        public string Descripcion { get; set; }
    }
}