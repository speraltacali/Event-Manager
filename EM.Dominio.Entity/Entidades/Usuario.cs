using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Usuarios")]
    [MetadataType(typeof(IUsuario))]
    public class Usuario : EntityBase
    {
        public string User { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public DateTime FechaCreacion { get; set; }

        public byte[] Foto { get; set; }

        //public long OcupacionId { get; set; }

        public long PersonaId { get; set; }

        //==========================================================//

        public virtual Persona Persona { get; set; }

        public virtual IEnumerable<CreadorEvento> CreadorEventos { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }

        //public virtual Ocupacion Ocupacion{ get; set; }

    }
}