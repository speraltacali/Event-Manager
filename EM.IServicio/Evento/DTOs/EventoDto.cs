using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Evento.DTOs
{
    public class EventoDto : DtoBase
    {
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Orante { get; set; }

        public string Organizacion { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public string Mail { get; set; }

        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public long TipoEventoId { get; set; }

        public byte[] Imagen { get; set; }
    }
}