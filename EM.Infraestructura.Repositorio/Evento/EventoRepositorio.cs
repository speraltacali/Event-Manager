using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Evento;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Evento
{
    public class EventoRepositorio : Repositorio<Dominio.Entity.Entidades.Evento> , IEventoRepositorio
    {
    }
}
