using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Comprobantes")]
    [MetadataType(typeof(IComprobante))]
    public abstract class Comprobante : EntityBase
    {
        public long Numero { get; set; }

        public string Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        public long TipoComprobanteId { get; set; }

        public long FormaPagoId { get; set; }

        public virtual TipoComprobante TiposComprobantes { get; set; }

        public virtual FormaPago FormasPagos { get; set; }
    }
}