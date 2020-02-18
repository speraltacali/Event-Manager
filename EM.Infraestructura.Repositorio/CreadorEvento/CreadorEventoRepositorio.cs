using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.CreadorEvento;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.CreadorEvento
{
    public class CreadorEventoRepositorio : Repositorio<Dominio.Entity.Entidades.CreadorEvento> , ICreadorEventoRepositorio
    {
    }
}
