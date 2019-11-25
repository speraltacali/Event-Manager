using EM.IServicio.Alojamiento.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Alojamiento
{
    public interface IAlojamientoServicio
    {
        IEnumerable<AlojamientoDto> ObtenerTodo();

        IEnumerable<AlojamientoDto> Obtener(string cadenaBuscar);

        AlojamientoDto ObtenerPorId(long id);

        void Insertar(AlojamientoDto dto);

        void Modificar(AlojamientoDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}