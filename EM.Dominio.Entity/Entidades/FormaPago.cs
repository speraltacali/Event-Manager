using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("FormaPago")]
    [MetadataType(typeof(IFormaPago))]
    public class FormaPago : EntityBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}