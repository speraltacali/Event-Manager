using EM.IServicio.Comprobante.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Comprobante
{
    public interface IComprobanteServicio
    {
        IEnumerable<ComprobanteDto> ObtenerTodo();

        IEnumerable<ComprobanteDto> Obtener(string cadena);

        ComprobanteDto ObtenerPoId(long id);

        ComprobanteDto Insertar(ComprobanteDto dto);

        long ObtenerCodigo();

        void Guardar();
    }
}