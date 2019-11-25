using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Fecha;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Fecha
{
    public class FechaRepositorio : Repositorio<Dominio.Entity.Entidades.Fecha> , IFechaRepositorio
    {
    }
}
