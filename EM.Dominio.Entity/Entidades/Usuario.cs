using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System;
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

        public long EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}