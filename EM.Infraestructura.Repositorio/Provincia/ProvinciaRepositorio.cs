using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Provincia;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Provincia
{
    public class ProvinciaRepositorio : Repositorio<Dominio.Entity.Entidades.Provincia> , IProvinciaRepositorio
    {
    }
}
