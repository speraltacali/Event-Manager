using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Localidades")]
    [MetadataType(typeof(ILocalidad))]
    public class Localidad : EntityBase
    {
        public long ProvinciaId { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Domicilio> Domicilios { get; set; }

        public virtual Provincia Provincia { get; set; }
    }
}