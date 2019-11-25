using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Gastronomia;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Gastronomia
{
    public class GastronomiaRepositorio : Repositorio<Dominio.Entity.Entidades.Gastronomia> , IGastronomiaRepositorio
    {
    }
}
