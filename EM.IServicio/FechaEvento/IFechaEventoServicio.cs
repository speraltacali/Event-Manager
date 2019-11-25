using EM.IServicio.FechaEvento.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.FechaEvento
{
    public interface IFechaEventoServicio
    {
        IEnumerable<FechaEventoDto> Get();

        IEnumerable<FechaEventoDto> GetByFilter(long eventoId);

        Dominio.Entity.Entidades.FechaEvento GetById(long id);

        void Insert(FechaEventoDto dto);

        void Update(FechaEventoDto dto);

        void Delete(long id);

        void Save();
    }
}