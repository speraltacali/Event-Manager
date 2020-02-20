using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using EM.Dominio.Entity.Enum;
using EM.Dominio.Entity.MetaData;
using EM.Servicio.Base.DtoBase;
using Microsoft.AspNetCore.Http;

namespace EM.IServicio.Evento.DTOs
{
    [MetadataType(typeof(IEventoView))]
    public class EventoViewDto : DtoBase
    {
        public string Titulo { get; set; }

        public string Orante { get; set; }

        public string Organizacion { get; set; }

        public string Descripcion { get; set; }

        public string Mail { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public long TipoEventoId { get; set; }

        public byte[] Imagen { get; set; }


        public string Calle { get; set; }

        public string CalleNumero { get; set; }

        public string Telefono { get; set; }

        public decimal Precio { get; set; }

        public long EntradaId { get; set; }

        public DateTime FechaEvento { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public EventoEstado Estado { get; set; }

        public string DomicilioCompleto => $"{Calle} {CalleNumero}";
    }
}
