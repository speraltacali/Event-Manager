using EM.Servicio.Base.DtoBase;
using System;
using System.ComponentModel.DataAnnotations;
using EM.Dominio.Entity.MetaData;

namespace EM.IServicio.Usuario.DTOs
{
    [MetadataType(typeof(IUsuario))]
    public class UsuarioDto : DtoBase
    {
        public string User { get; set; }

        public string Password { get; set; }

        public string PasswordRep { get; set; }

        public DateTime FechaCreacion { get; set; }

        public long PersonaId { get; set; }

        //public long EmpresaId { get; set; }
    }
}