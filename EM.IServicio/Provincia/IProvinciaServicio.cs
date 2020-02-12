using EM.IServicio.Provincia.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Provincia
{
    public interface IProvinciaServicio
    {
        void Insertar(ProvinciaDto provincia);

        void Modificar(ProvinciaDto provincia);

        void Eliminar(long id);

        IEnumerable<ProvinciaDto> Obtener();

        IEnumerable<ProvinciaDto> ObtenerPorFiltro(string cadena);

        ProvinciaDto ObtenerPorId(long id);

        void InsertarPorDefecto();
    }
}