using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Alojamiento;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Alojamiento
{
    public class AlojamientoRepositorio : Repositorio<Dominio.Entity.Entidades.Alojamiento> , IAlojamientoRepositorio
    {
    }
}
