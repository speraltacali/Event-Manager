using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.Usuario.DTOs
{
    public class UsuarioDto : DtoBase
    {
        public string User { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public DateTime FechaCreacion { get; set; }

        public long EmpresaId { get; set; }
    }
}