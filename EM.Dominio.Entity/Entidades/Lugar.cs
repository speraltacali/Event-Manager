using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Lugares")]
    [MetadataType(typeof(ILugar))]
    public class Lugar : EntityBase
    {
        public string Descripcion { get; set; }

        public long DomicilioId { get; set; }

        //**********************************************************//

        public virtual Domicilio Domicilio { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }

        public virtual ICollection<Alojamiento> Alojamientos { get; set; }

        public virtual ICollection<EventoLugar> EventosLugares { get; set; }

        public virtual ICollection<Gastronomia> Gastronomias { get; set; }

        public virtual ICollection<Transporte> Transportes { get; set; }
    }
}