using EM.IServicio.EventoLugar.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.EventoLugar
{
    public interface IEventoLugarServicio
    {
        IEnumerable<EventoLugarDto> ObtenerTodo();

        IEnumerable<EventoLugarDto> Obtener(string cadenaBuscar);

        EventoLugarDto ObtenerPorId(long id);

        void Insertar(EventoLugarDto dto);

        void Modificar(EventoLugarDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}