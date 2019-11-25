using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Empresa;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Empresa
{
    public class EmpresaRepositorio : Repositorio<Dominio.Entity.Entidades.Empresa> , IEmpresaRepositorio
    {
    }
}
