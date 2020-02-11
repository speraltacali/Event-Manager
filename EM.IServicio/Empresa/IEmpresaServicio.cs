using EM.IServicio.Empresa.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Empresa
{
    public interface IEmpresaServicio
    {
        void Insertar(EmpresaDto empresa);

        void Modificar(EmpresaDto empresa);

        void Eliminar(long id);

        IEnumerable<EmpresaDto> Obtener();

        IEnumerable<EmpresaDto> ObtenerPorFiltro(string buscar);

        EmpresaDto ObtenerPorId(long id);
    }
}