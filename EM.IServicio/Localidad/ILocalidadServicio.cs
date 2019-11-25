using EM.IServicio.Localidad.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Localidad
{
    public interface ILocalidadServicio
    {
        IEnumerable<LocalidadDto> ObtenerTodo();

        IEnumerable<LocalidadDto> Obtener(string cadenaBuscar);

        LocalidadDto ObtenerPorId(long id);

        void Insertar(LocalidadDto dto);

        void Modificar(LocalidadDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}