using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.InscripcionCuenta;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.InscripcionCuenta
{
    public class InscripcionCuentaRepositorio : Repositorio<Dominio.Entity.Entidades.InscripcionCuenta> , IInscripcionCuentaRepositorio
    {
    }
}
