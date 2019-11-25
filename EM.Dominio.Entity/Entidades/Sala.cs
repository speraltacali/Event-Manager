using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Salas")]
    [MetadataType(typeof(ISala))]
    public class Sala : EntityBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }

        public int Capacidad { get; set; }

        public virtual Lugar Lugar { get; set; }
    }
}