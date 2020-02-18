using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;

namespace EM.Dominio.Entity.Entidades
{
    [Table("CreadorEvento")]
    [MetadataType(typeof(ICreadorEvento))]
    public class CreadorEvento : EntityBase
    {
        public long EventoId { get; set; }

        public long UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        //*************************************************//


        public virtual Evento Eventos { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
