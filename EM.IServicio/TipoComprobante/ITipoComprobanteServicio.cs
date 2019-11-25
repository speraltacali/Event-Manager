using EM.IServicio.TipoComprobante.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.TipoComprobante
{
    public interface ITipoComprobanteServicio
    {
        IEnumerable<TipoComprobanteDto> Get();

        IEnumerable<TipoComprobanteDto> GetByFilter(string cadenaBuscar);

        Dominio.Entity.Entidades.TipoComprobante GetById(long id);

        void Insert(TipoComprobanteDto dto);

        void Update(TipoComprobanteDto dto);

        void Delete(long id);

        void Save();
    }
}