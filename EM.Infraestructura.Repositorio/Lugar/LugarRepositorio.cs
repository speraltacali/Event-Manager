using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Lugar;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Lugar
{
    public class LugarRepositorio : Repositorio<Dominio.Entity.Entidades.Lugar> , ILugarRepositorio
    {
    }
}
