using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.Evento;
using EM.Dominio.Repositorio.PersonaEvento;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.PersonaEvento
{
    public class PersonaEventoRepositorio : Repositorio<Dominio.Entity.Entidades.PersonaEvento> , IPersonaEventoRepositorio
    {
    }
}
