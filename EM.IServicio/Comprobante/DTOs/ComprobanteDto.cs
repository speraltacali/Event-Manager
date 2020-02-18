using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Comprobante.DTOs
{
    public class ComprobanteDto : DtoBase
    {
        public long Numero { get; set; }

        public string Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        public long EventoId { get; set; }

        public long UsuarioId { get; set; }
    }
}