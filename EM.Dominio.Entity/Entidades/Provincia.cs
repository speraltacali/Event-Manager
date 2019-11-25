using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Provincias")]
    [MetadataType(typeof(IProvincia))]
    public class Provincia : EntityBase
    {
        public long PaisId { get; set; }

        public string Descripcion { get; set; }

        //Propiedades de navegacion

        public virtual ICollection<Localidad> Localidades { get; set; }

        public virtual Pais Pais { get; set; }
    }
}