using EM.IServicio.PersonaEvento.DTOs;
using System;
using System.Collections.Generic;

namespace EM.IServicio.PersonaEvento
{
    public interface IPersonaEventoServicio
    {
        IEnumerable<PersonaEventoDto> Get();

        IEnumerable<PersonaEventoDto> GetByFilter(DateTime fecha);

        Dominio.Entity.Entidades.PersonaEvento GetById(long id);

        void Insert(PersonaEventoDto dto);

        void Update(PersonaEventoDto dto);

        void Delete(long id);

        void Save();
    }
}