using EM.IServicio.Comprobante.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Comprobante
{
    public interface IComprobanteServicio
    {
        IEnumerable<ComprobanteDto> ObtenerTodo();

        IEnumerable<ComprobanteDto> Obtener(string cadena);

        ComprobanteDto ObtenerPorEventoUser(long eventoId, long userId);

        List<ComprobanteDto> ObtenerPoIdUsuario(long id);

        ComprobanteDto ObtenerPoId(long id);

        ComprobanteDto Insertar(ComprobanteDto dto);

        decimal TotalComprobantePorEvento(long eventoId);

        long ObtenerCodigo();

        bool ValidarCómprobanteEvento(long eventoId, long userId);

        void Guardar();
    }
}