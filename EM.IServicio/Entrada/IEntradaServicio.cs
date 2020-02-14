using EM.IServicio.Entrada.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Entrada
{
    public interface IEntradaServicio
    {
        IEnumerable<EntradaDto> ObtenerTodo();

        IEnumerable<EntradaDto> Obtener(string cadenaBuscar);

        EntradaDto ObtenerPorIdEvento(long eventoId);

        EntradaDto ObtenerPotId(long id);

        EntradaDto Insertar(EntradaDto dto);

        EntradaDto Modificar(EntradaDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}