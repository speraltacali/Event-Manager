using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.CondicionIva;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.CondicionIva
{
    public class CondicionIvaRepositorio : Repositorio<Dominio.Entity.Entidades.CondicionIva> , ICondicionIvaRepositorio
    {
    }
}
