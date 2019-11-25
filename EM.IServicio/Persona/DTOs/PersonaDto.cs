using EM.Servicio.Base.DtoBase;
using System;

namespace EM.IServicio.Persona.DTOs
{
    public class PersonaDto : DtoBase
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Cuil { get; set; }

        public string Mail { get; set; }

        public string Telefono { get; set; }

        public string Domicilio { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}