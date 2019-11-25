using EM.IServicio.FormaPago.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.FormaPago
{
    public interface IFormaPagoServicio
    {
        IEnumerable<FormaPagoDto> ObtenerTodo();

        IEnumerable<FormaPagoDto> Obtener(string cadenaBuscar);

        FormaPagoDto ObtenerPorId(long id);

        void Insertar(FormaPagoDto dto);

        void Modificar(FormaPagoDto dto);

        void Eliminar(long id);

        void Guardar();
    }
}