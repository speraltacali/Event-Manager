using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.IServicio.CondicionIva.DTOs;

namespace EM.IServicio.CondicionIva
{
    public interface ICondicionIvaServicio
    {
        void Insertar(CondicionIvaDto iva);

        void Modificar(CondicionIvaDto iva);

        void Eliminar(long id);

        IEnumerable<CondicionIvaDto> ObtenerPorFiltro(string buscar);

        IEnumerable<CondicionIvaDto> Obtener();

        CondicionIvaDto ObtenerPorId(long id);
    }
}
