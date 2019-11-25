using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.EventoLugar;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.EventoLugar
{
    public class EventoLugarRepositorio : Repositorio<Dominio.Entity.Entidades.EventoLugar> , IEventoLugarRepositorio
    {
    }
}
