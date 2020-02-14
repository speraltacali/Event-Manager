using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Fecha")]
    [MetadataType(typeof(IFecha))]
    public class Fecha : EntityBase
    {
        public DateTime FechaEvento { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraCierre { get; set; }

        public virtual ICollection<FechaEvento> FechasEventos { get; set; }
    }
}