using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.TipoComprobante;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.TipoComprobante
{
    public class TipoComprobanteRepositorio : Repositorio<Dominio.Entity.Entidades.TipoComprobante> , ITipoComprobanteRepositorio
    {
    }
}
