using EM.IServicio.InscripcionCuenta.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.InscripcionCuenta
{
    public interface IInscripcionCuentaServicio
    {
        IEnumerable<InscripcionCuentaDto> Get();

        IEnumerable<InscripcionCuentaDto> GetByFilter(long estadoId);

        Dominio.Entity.Entidades.InscripcionCuenta GetById(long id);

        void Insert(InscripcionCuentaDto dto);

        void Update(InscripcionCuentaDto dto);

        void Delete(long id);

        void Save();
    }
}