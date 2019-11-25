using EM.IServicio.Lugar.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Lugar
{
    public interface ILugarServicio
    {
        IEnumerable<LugarDto> ObtenerTodo();

        IEnumerable<LugarDto> Obtener(string cadenaBuscar);

        LugarDto ObtenerPorId(long id);

        void Insertar(LugarDto dto);

        void Modificar(LugarDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}