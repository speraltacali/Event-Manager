using EM.IServicio.Entrada.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Entrada
{
    public interface IEntradaServicio
    {
        IEnumerable<EntradaDto> ObtenerTodo();

        IEnumerable<EntradaDto> Obtener(string cadenaBuscar);

        EntradaDto ObtenerPotId(long id);

        void Insertar(EntradaDto dto);

        void Modificar(EntradaDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}