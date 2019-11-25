using EM.IServicio.Ocupacion.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Ocupacion
{
    public interface IOcupacionServicio
    {
        IEnumerable<OcupacionDto> Get();

        IEnumerable<OcupacionDto> GetByFilter(string cadenaBuscar);

        Dominio.Entity.Entidades.Ocupacion GetById(long id);

        void Insert(OcupacionDto dto);

        void Update(OcupacionDto dto);

        void Delete(long id);

        void Save();
    }
}