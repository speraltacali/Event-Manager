using EM.IServicio.Evento.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Evento
{
    public interface IEventoServicio
    {
        IEnumerable<EventoDto> ObtenerTodo();

        IEnumerable<EventoDto> Obtener(string cadenaBuscar);

        EventoDto ObtenerPorId(long id);

        void Insertar(EventoDto dto);

        void Modificar(EventoDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}