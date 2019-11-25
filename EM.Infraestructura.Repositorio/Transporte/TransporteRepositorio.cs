using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Transporte;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Transporte
{
    public class TransporteRepositorio : Repositorio<Dominio.Entity.Entidades.Transporte> , ITransporteRepositorio
    {
    }
}
