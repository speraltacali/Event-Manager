using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("EventosLugares")]
    [MetadataType(typeof(IEventoLugar))]
    public class EventoLugar : EntityBase
    {
        public long EventoId { get; set; }

        public long LugarId { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual Lugar Lugar { get; set; }
    }
}