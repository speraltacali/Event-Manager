using System.Collections.Generic;
using EM.IServicio.ComprobanteFactura.DTOs;

namespace EM.IServicio.ComprobanteFactura
{
    public interface IComprobanteFacturaServicio
    {
        IEnumerable<ComprobanteFacturaDto> Get();

        IEnumerable<ComprobanteFacturaDto> GetByFilter(long numero);

        Dominio.Entity.Entidades.ComprobanteFactura GetById(long id);

        void Insert(ComprobanteFacturaDto dto);

        void Update(ComprobanteFacturaDto dto);

        void Delete(long id);

        void Save();
    }
}
