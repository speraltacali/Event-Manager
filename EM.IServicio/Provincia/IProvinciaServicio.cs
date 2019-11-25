using EM.IServicio.Provincia.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Provincia
{
    public interface IProvinciaServicio
    {
        void Insertar(ProvinciaDto provincia);

        void Modificar(ProvinciaDto provincia);

        void Eliminar(long id);

        IEnumerable<ProvinciaDto> Obtener(string cadena);

        ProvinciaDto ObtenerPorId(long id);
    }
}