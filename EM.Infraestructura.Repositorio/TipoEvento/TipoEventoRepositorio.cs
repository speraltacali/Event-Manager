using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.TipoEvento;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.TipoEvento
{
    public class TipoEventoRepositorio : Repositorio<Dominio.Entity.Entidades.TipoEvento> , ITipoEventoRepositorio
    {
    }
}
