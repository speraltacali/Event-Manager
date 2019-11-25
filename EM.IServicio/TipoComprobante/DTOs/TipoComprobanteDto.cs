using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.TipoComprobante.DTOs
{
    public class TipoComprobanteDto : DtoBase
    {
        public string Descripcion { get; set; }

        public char Letra { get; set; }

        public long EmpresaId { get; set; }
    }
}