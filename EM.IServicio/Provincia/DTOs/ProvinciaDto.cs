using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Provincia.DTOs
{
    public class ProvinciaDto : DtoBase
    {
        public long PaisId { get; set; }

        public string Descripcion { get; set; }
    }
}