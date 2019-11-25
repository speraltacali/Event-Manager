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
        public DateTime FechaInicio { get; set; }

        public DateTime FechaCierre { get; set; }

        public virtual ICollection<FechaEvento> FechasEventos { get; set; }
    }
}