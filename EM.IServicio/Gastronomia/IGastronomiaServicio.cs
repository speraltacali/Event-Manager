using EM.IServicio.Gastronomia.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Gastronomia
{
    public interface IGastronomiaServicio
    {
        IEnumerable<GastronomiaDto> ObtenerTodo();

        IEnumerable<GastronomiaDto> Obtener(string cadenaBuscar);

        GastronomiaDto ObtenerPorId(long id);

        void Insertar(GastronomiaDto dto);

        void Modificar(GastronomiaDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}