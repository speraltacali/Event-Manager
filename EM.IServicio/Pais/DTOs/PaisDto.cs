using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Pais.DTOs
{
    public class PaisDto : DtoBase
    {
        public string Descripcion { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }
    }
}