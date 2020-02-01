using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Eventos")]
    [MetadataType(typeof(IEvento))]
    public class Evento : EntityBase
    {
        public long EmpresaId { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Mail { get; set; }

        public long TipoEventoId { get; set; }

        public byte[] Imagen { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Entrada> Entradas { get; set; }

        public virtual ICollection<EventoLugar> EventosLugares { get; set; }

        public virtual ICollection<FechaEvento> FechasEventos { get; set; }

        public virtual ICollection<InscripcionCuenta> InscripcionesCuentas { get; set; }

        public virtual ICollection<PersonaEvento> PersonasEventos { get; set; }

        public virtual TipoEvento TiposEventos { get; set; }
    }
}