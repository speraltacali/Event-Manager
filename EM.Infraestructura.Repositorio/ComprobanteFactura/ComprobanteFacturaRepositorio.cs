using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.ComprobanteFactura;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.ComprobanteFactura
{
    public class ComprobanteFacturaRepositorio : Repositorio<Dominio.Entity.Entidades.ComprobanteFactura> , IComprobanteFacturaRepositorio
    {
    }
}
