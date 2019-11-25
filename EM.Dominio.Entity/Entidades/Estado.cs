using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Estados")]
    [MetadataType(typeof(IEstado))]
    public class Estado : EntityBase
    {
        public string Descripcion { get; set; }

        public virtual ICollection<PersonaEvento> PersonasEventos { get; set; }
    }
}