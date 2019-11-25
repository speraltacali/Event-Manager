using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Entradas")]
    [MetadataType(typeof(IEntrada))]
    public class Entrada : EntityBase
    {
        public decimal Monto { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public int Cantidad { get; set; }

        public long EventoId { get; set; }

        public virtual ICollection<InscripcionCuenta> InscripcionesCuentas { get; set; }

        public virtual Evento Eventos { get; set; }
    }
}