using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Comprobante;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Comprobante
{
    public class ComprobanteRepositorio : Repositorio<Dominio.Entity.Entidades.Comprobante> , IComprobanteRepositorio
    {
    }
}
