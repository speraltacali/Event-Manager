using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Ocupacion;
using EM.Infraestructura.Context;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Ocupacion
{
    public class OcupacionRepositorio : Repositorio<Dominio.Entity.Entidades.Ocupacion>, IOcupacionRepositorio
    {
       
    }
}
