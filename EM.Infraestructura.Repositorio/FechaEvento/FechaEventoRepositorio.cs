using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.FechaEvento;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.FechaEvento
{
    public class FechaEventoRepositorio : Repositorio<Dominio.Entity.Entidades.FechaEvento> , IFechaEventoRepositorio
    {
    }
}
