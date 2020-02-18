using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("TipoComprobante")]
    [MetadataType(typeof(ITipoComprobante))]
    public class TipoComprobante : EntityBase
    {
        public string Descripcion { get; set; }

        public char Letra { get; set; }

        public long EmpresaId { get; set; }

        //public virtual ICollection<Comprobante> Comprobantes { get; set; }

        public virtual Empresa Empresas { get; set; }
    }
}