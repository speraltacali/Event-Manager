using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("ComprobantesFacturas")]
    [MetadataType(typeof(IComprobanteFactura))]
    public class ComprobanteFactura : Comprobante
    {
        public long IncripcionCuentaId { get; set; }

        public virtual InscripcionCuenta InscripcionesCuentas { get; set; }
    }
}