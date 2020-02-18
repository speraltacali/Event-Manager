using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.IServicio.TarjetaDebito.DTO;

namespace EM.IServicio.TarjetaDebito
{
    public interface ITarjetaDebitoServicio
    {
        void Insertar(TarjetaDebitoDto dto);

        void Modificar(TarjetaDebitoDto dto);

        void Eliminar(long id);

        IEnumerable<TarjetaDebitoDto> Obtener();

        IEnumerable<TarjetaDebitoDto> ObtenerPorFiltro(string cadena);

        TarjetaDebitoDto ObtenerPorId(long id);

        void Guardar();

    }
}
