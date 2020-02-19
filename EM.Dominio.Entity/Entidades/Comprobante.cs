using System;
using System.Collections.Generic;
using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Comprobantes")]
    [MetadataType(typeof(IComprobante))]
    public class Comprobante : EntityBase
    {
        public long Numero { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        public long EventoId { get; set; }

        public long UsuarioId { get; set; }

        //public virtual TipoComprobante TiposComprobantes { get; set; }

        //public virtual FormaPago FormasPagos { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual ICollection<TarjetaDebito> TarjetaDebitos { get; set; }
    }
}