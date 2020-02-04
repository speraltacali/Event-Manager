using EM.IServicio.Ocupacion.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Ocupacion
{
    public interface IOcupacionServicio
    {
        IEnumerable<OcupacionDto> Obtener();

        IEnumerable<OcupacionDto> ObtenerPorFiltro(string cadenaBuscar);

        Dominio.Entity.Entidades.Ocupacion ObtenerPorId(long id);

        void Agregar(OcupacionDto dto);

        void Modificar(OcupacionDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}