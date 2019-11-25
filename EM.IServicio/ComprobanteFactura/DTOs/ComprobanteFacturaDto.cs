using EM.IServicio.Comprobante.DTOs;
using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.ComprobanteFactura.DTOs
{
    public class ComprobanteFacturaDto : ComprobanteDto
    {
        public long IncripcionCuentaId { get; set; }
    }
}
