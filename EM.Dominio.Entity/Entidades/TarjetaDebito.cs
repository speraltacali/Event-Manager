using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;

namespace EM.Dominio.Entity.Entidades
{
    [Table("TarjetaDebito")]
    [MetadataType(typeof(ITarjetaDebito))]
    public class TarjetaDebito : EntityBase
    {
        public string NombreTitular { get; set; }

        public string Tarjeta { get; set; }

        public string Mes { get; set; }

        public string Año { get; set; }

        public string CCV { get; set; }

        public long ComprobanteId { get; set; }

        //**************************************************//

        public virtual Comprobante Comprobante { get; set; }
    }
}
