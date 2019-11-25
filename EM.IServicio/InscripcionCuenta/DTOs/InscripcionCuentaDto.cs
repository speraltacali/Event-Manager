using EM.Dominio.Entity;
using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.InscripcionCuenta.DTOs
{
    public class InscripcionCuentaDto : DtoBase
    {
        public decimal Monto { get; set; }

        public Operacion Operacion { get; set; }

        public long EventoId { get; set; }

        public long EntradaId { get; set; }
    }
}