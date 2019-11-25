using EM.IServicio.Sala.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Sala
{
    public interface ISalaServicio
    {
        IEnumerable<SalaDto> ObtenerTodo();

        IEnumerable<SalaDto> Obtener(string cadenaBuscar);

        SalaDto ObtenerPorId(long id);

        void Insertar(SalaDto dto);

        void Modificar(SalaDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}