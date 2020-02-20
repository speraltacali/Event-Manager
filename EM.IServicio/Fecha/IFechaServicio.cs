using EM.IServicio.Fecha.DTOs;
using System;
using System.Collections.Generic;

namespace EM.IServicio.Fecha
{
    public interface IFechaServicio
    {
        IEnumerable<FechaDto> Obtener();

        IEnumerable<FechaDto> ObtenerPorFiltro(DateTime fecha);

        FechaDto ObtenerPorId(long id);

        FechaDto Insertar(FechaDto dto);

        void Modificar(FechaDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}