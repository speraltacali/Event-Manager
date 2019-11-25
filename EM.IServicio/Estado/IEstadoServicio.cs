using EM.IServicio.Estado.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Estado
{
    public interface IEstadoServicio
    {
        IEnumerable<EstadoDto> Get();

        IEnumerable<EstadoDto> GetByFilter(string cadenaBuscar);

        Dominio.Entity.Entidades.Estado GetById(long id);

        void Insert(EstadoDto dto);

        void Update(EstadoDto dto);

        void Delete(long id);

        void Save();
    }
}