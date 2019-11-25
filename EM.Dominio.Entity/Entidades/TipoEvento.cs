using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("TiposEventos")]
    [MetadataType(typeof(ITipoEvento))]
    public class TipoEvento : EntityBase
    {
        public string Descripcion { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}