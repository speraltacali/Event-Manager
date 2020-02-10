using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Paises")]
    [MetadataType(typeof(IPais))]
    public class Pais : EntityBase
    {
        public string Descripcion { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }

        //propiedades de navegación

        public virtual ICollection<Provincia> Provincias { get; set; }
    }
}