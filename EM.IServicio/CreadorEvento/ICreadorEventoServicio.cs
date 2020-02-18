using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.IServicio.CreadorEvento.DTO;
using EM.IServicio.Evento.DTOs;

namespace EM.IServicio.CreadorEvento
{
    public interface ICreadorEventoServicio
    {
        IEnumerable<CreadorEventoDto> ObtenerTodo();

        IEnumerable<EventoDto> ObtenerPorCreador(long id);

        bool ValidarAlCreador(long User, long Event);

        IEnumerable<CreadorEventoDto> Obtener(string cadenaBuscar);

        CreadorEventoDto ObtenerPorId(long id);

        void Insertar(CreadorEventoDto dto);

        void Modificar(CreadorEventoDto dto);

        void Eliminar(long id);

        void Guardar();

    }
}
