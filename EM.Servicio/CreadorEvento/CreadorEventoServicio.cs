using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.CreadorEvento;
using EM.Dominio.Repositorio.Evento;
using EM.Infraestructura.Repositorio.CreadorEvento;
using EM.Infraestructura.Repositorio.Evento;
using EM.IServicio.CreadorEvento;
using EM.IServicio.CreadorEvento.DTO;
using EM.IServicio.Evento.DTOs;

namespace EM.Servicio.CreadorEvento
{
    public class CreadorEventoServicio : ICreadorEventoServicio
    {
        private readonly ICreadorEventoRepositorio _creadorEventoRepositorio = new CreadorEventoRepositorio();
        private readonly IEventoRepositorio _eventoRepositorio = new EventoRepositorio();

        public IEnumerable<CreadorEventoDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreadorEventoDto> Obtener(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public CreadorEventoDto ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CreadorEventoDto dto)
        {
            var UserEvento = new Dominio.Entity.Entidades.CreadorEvento()
            {
                EventoId = dto.EventoId,
                UsuarioId = dto.UsuarioId,
                Fecha = dto.Fecha
            };

            _creadorEventoRepositorio.Add(UserEvento);
            Guardar();
        }

        public void Modificar(CreadorEventoDto dto)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _creadorEventoRepositorio.Save();
        }

        public bool ValidarAlCreador(long User , long Event)
        {
            var Validar = _creadorEventoRepositorio.GetAll().Any();

            if (Validar)
            {
                var Obj =_creadorEventoRepositorio.GetByFilter(x => x.EventoId == Event && x.UsuarioId == User);

                if (Obj.Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<EventoDto> ObtenerPorCreador(long id)
        {
            var Validar = _creadorEventoRepositorio.GetAll().Any();

            List<EventoDto> ListaEventos = new List<EventoDto>();

            if(Validar)
            {
                var UserEvento = _creadorEventoRepositorio.GetByFilter(x => x.UsuarioId == id)
                    .Select(x => new CreadorEventoDto()
                    {
                        EventoId = x.EventoId,
                        UsuarioId = x.UsuarioId,
                        Fecha = x.Fecha
                    }).ToList();

                foreach (var evento in UserEvento)
                {
                    var Evento =_eventoRepositorio.GetById(evento.EventoId);

                    ListaEventos.Add(new EventoDto()
                    {
                        Id = Evento.Id,
                        Titulo = Evento.Titulo,
                        Descripcion = Evento.Descripcion,
                        Mail = Evento.Mail,
                        TipoEventoId = Evento.TipoEventoId,
                        Orante = Evento.Orante,
                        Organizacion = Evento.Organizacion,
                        Latitud = Evento.Latitud,
                        Longitud = Evento.Longitud,
                        Domicilio = Evento.Domicilio,
                        Telefono = Evento.Telefono,
                        Imagen = Evento.Imagen
                    });
                }

                return ListaEventos.ToList();

            }
            else
            {
                return null;
            }
        }
    }
}
