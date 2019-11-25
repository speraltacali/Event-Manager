using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Estado;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Estado
{
    public class EstadoRepositorio : Repositorio<Dominio.Entity.Entidades.Estado> , IEstadoRepositorio
    {
    }
}
