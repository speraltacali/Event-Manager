using EM.Dominio.Entity.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Dominio.Base;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Personas")]
    [MetadataType(typeof(IPersona))]
    public class Persona : EntityBase
    {
        //Propiedades
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Cuil { get; set; }

        public string Mail { get; set; }

        public string Telefono { get; set; }

        public string Domicilio { get; set; }

        public DateTime FechaNacimiento { get; set; }
        
        public virtual ICollection<PersonaEvento> PersonasEventos { get; set; }
    }
}