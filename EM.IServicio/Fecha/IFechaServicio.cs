using EM.IServicio.Fecha.DTOs;
using System;
using System.Collections.Generic;

namespace EM.IServicio.Fecha
{
    public interface IFechaServicio
    {
        IEnumerable<FechaDto> Get();

        IEnumerable<FechaDto> GetByFilter(DateTime fecha);

        Dominio.Entity.Entidades.Fecha GetById(long id);

        void Insert(FechaDto dto);

        void Update(FechaDto dto);

        void Delete(long id);

        void Save();
    }
}