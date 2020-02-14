using System;
using EM.IServicio.FechaEvento.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.FechaEvento
{
    public interface IFechaEventoServicio
    {
        IEnumerable<FechaEventoDto> Obtener();

        IEnumerable<FechaEventoDto> ObtenerPorFiltro(DateTime fecha);

        FechaEventoDto ObtenerPorId(long id);

        FechaEventoDto ObtenerPorIdEvento(long idEvento);

        FechaEventoDto Insertar(FechaEventoDto dto);

        FechaEventoDto Modificar(FechaEventoDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}