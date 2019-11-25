using EM.IServicio.Usuario.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Usuario
{
    public interface IUsuarioServicio
    {
        IEnumerable<UsuarioDto> ObtenerTodo();

        IEnumerable<UsuarioDto> Obtener(string cadenaBuscar);

        UsuarioDto ObtenerPorId(long id);

        void Insertar(UsuarioDto dto);

        void Modificar(UsuarioDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}