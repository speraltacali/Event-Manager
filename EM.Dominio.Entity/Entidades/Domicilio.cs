using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Domicilios")]
    [MetadataType(typeof(IDomicilio))]
    public class Domicilio : EntityBase
    {
        public long LocalidadId { get; set; }

        public string Descripción { get; set; }

        public virtual Localidad Localidades { get; set; }
    }
}