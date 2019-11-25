using EM.IServicio.Transporte.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Transporte
{
    public interface ITransporteServicio
    {
        IEnumerable<TransporteDto> ObtenerTodo();

        IEnumerable<TransporteDto> Obtener(string cadenaBuscar);

        TransporteDto ObtenerPorId(long id);

        void Insertar(TransporteDto dto);

        void Modificar(TransporteDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}