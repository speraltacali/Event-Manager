using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Ocupaciones")]
    [MetadataType(typeof(IOcupacion))]
    public class Ocupacion : EntityBase
    {
        public string Descripcion { get; set; }

        //public virtual ICollection<Persona> Personas { get; set; }
    }
}