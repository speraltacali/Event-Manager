using System;
using EM.IServicio.Evento.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Evento
{
    public interface IEventoServicio
    {
        IEnumerable<EventoDto> ObtenerTodo();

        IEnumerable<EventoDto> Obtener(string cadenaBuscar);

        EventoDto ObtenerPorId(long id);

        EventoDto ObtenerPorTitulo(string cadenaBuscar);

        EventoDto Insertar(EventoDto dto);

        EventoDto Modificar(EventoDto dto);

        void Eliminar(long id);

        void Guardar();

        void EstadoSuspendido(long id);

        void EstadoVencido(long id);

        bool ValidarTitulo(string Titulo);

        bool ValidarFecha(DateTime fecha);
    }
}