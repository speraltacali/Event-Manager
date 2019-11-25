using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Evento.DTOs
{
    public class EventoDto : DtoBase
    {
        public long EmpresaId { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Mail { get; set; }

        public long TipoEventoId { get; set; }

        public byte[] Imagen { get; set; }
    }
}