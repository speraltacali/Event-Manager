using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.MetaData;
using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Usuario.DTOs
{
    [MetadataType(typeof(IUsuarioView))]
    public class UsuarioViewDto : DtoBase
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Cuil { get; set; }

        public string Mail { get; set; }

        public string Telefono { get; set; }

        public string Domicilio { get; set; }

        public DateTime FechaNacimiento { get; set; }

        //******************************************//

        public string User { get; set; }

        public string Password { get; set; }

        public string PasswordRep { get; set; }

        public DateTime FechaCreacion { get; set; }

        public long PersonaId { get; set; }
    }
}
