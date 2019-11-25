using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Entrada;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Entrada
{
    public class EntradaRepositorio : Repositorio<Dominio.Entity.Entidades.Entrada> , IEntradaRepositorio
    {
    }
}
