using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Inscripcion_Cuenta")]
    [MetadataType(typeof(IInscripcionCuenta))]
    public class InscripcionCuenta : EntityBase
    {
        public decimal Monto { get; set; }

        public Operacion Operacion { get; set; }

        public long EventoId { get; set; }

        public long EntradaId { get; set; }

        public virtual Entrada Entradas { get; set; }

        public virtual Evento Eventos { get; set; }
    }
}