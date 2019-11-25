using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("FechasEventos")]
    [MetadataType(typeof(IFechaEvento))]
    public class FechaEvento : EntityBase
    {
        public long EventosId { get; set; }

        public long FechaId { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual Fecha Fecha { get; set; }
    }
}