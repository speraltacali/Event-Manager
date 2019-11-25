using EM.IServicio.Pais.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Pais
{
    public interface IPaisServicio
    {
        void Insertar(PaisDto pais);

        void Modificar(PaisDto pais);

        void Eliminar(long Id);

        IEnumerable<PaisDto> Obtener(string cadenabuscar);

        PaisDto ObtenerPorId(long Id);
    }
}