using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Localidad;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Localidad
{
    public class LocalidadRepositorio : Repositorio<Dominio.Entity.Entidades.Localidad> , ILocalidadRepositorio
    {
    }
}
