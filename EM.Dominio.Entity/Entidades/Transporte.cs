using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Transportes")]
    [MetadataType(typeof(ITransporte))]
    public class Transporte : EntityBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }

        public virtual Lugar Lugar { get; set; }
    }
}