using EM.IServicio.TipoEvento.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.TipoEvento
{
    public interface ITipoEventoServicio
    {
        IEnumerable<TipoEventoDto> Get();

        IEnumerable<TipoEventoDto> GetByFilter(string cadenaBuscar);

        Dominio.Entity.Entidades.TipoEvento GetById(long id);

        TipoEventoDto ObtenerId(long id);

        void Insert(TipoEventoDto dto);

        void Update(TipoEventoDto dto);

        void Delete(long id);

        void InsertarPorDefecto();

        void Save();
    }
}