using EM.Servicio.Base.DtoBase;
using System;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;

namespace EM.IServicio.Persona.DTOs
{
    [MetadataType(typeof(IPersona))]
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