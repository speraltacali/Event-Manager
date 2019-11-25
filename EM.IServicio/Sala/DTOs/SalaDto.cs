using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Sala.DTOs
{
    public class SalaDto : DtoBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }

        public int Capacidad { get; set; }
    }
}