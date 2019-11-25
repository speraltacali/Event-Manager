using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("PersonasEventos")]
    [MetadataType(typeof(IPersonaEvento))]
    public class PersonaEvento : EntityBase
    {
        public long PersonaId { get; set; }

        public long EventoId { get; set; }

        public DateTime Fecha { get; set; }

        public long EstadoId { get; set; }

        public virtual Estado Estados { get; set; }

        public virtual Evento Eventos { get; set; }

        public virtual Persona Personas { get; set; }
    }
}