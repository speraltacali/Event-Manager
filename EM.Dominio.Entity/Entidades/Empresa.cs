using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Empresas")]
    [MetadataType(typeof(IEmpresa))]
    public class Empresa : EntityBase
    {
        public string Cuil { get; set; }

        public string NombreFantasia { get; set; }

        public string RazonSocial { get; set; }

        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public byte[] Imagen { get; set; }

        public bool Eliminado { get; set; }

        //==============================================================================//

        public virtual CondicionIva CondicionIva { get; set; }

        //public virtual ICollection<Evento> Eventos { get; set; }

        public virtual ICollection<TipoComprobante> TiposComprobantes { get; set; }

        //Podemos diferentes perfiles tal como Empleado - oyentes y no todos puden estar asociados a una empresa 

        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}