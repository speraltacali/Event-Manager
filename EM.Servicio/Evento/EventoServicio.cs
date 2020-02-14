using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Evento;
using EM.Infraestructura.Repositorio.Evento;
using EM.IServicio.Evento;
using EM.IServicio.Evento.DTOs;
using EM.IServicio.EventoLugar.DTOs;

namespace EM.Servicio.Evento
{
    public class EventoServicio : IEventoServicio
    {
        private readonly IEventoRepositorio _eventoRepositorio = new EventoRepositorio();

        public IEnumerable<EventoDto> ObtenerTodo()
        {
            return _eventoRepositorio.GetAll()
                .Select(x => new EventoDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Mail = x.Mail,
                    TipoEventoId = x.TipoEventoId,
                    Imagen = x.Imagen
                }).ToList();
        }

        public IEnumerable<EventoDto> Obtener(string cadenaBuscar)
        {
            return _eventoRepositorio.GetByFilter(x=>x.Descripcion.Contains(cadenaBuscar)
            || x.TiposEventos.Descripcion.Contains(cadenaBuscar)
            || x.Titulo.Contains(cadenaBuscar))
                .Select(x => new EventoDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Mail = x.Mail,
                    TipoEventoId = x.TipoEventoId,
                    Imagen = x.Imagen
                }).ToList();
        }

        public EventoDto ObtenerPorTitulo(string cadenaBuscar)
        {
            var lista = _eventoRepositorio.GetByFilter(x => x.Titulo.Contains(cadenaBuscar))
                .Select(x => new EventoDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Mail = x.Mail,
                    TipoEventoId = x.TipoEventoId,
                    Imagen = x.Imagen
                }).ToList();

            var listaResult = lista.FirstOrDefault(x => x.Titulo == cadenaBuscar);

            return listaResult;
        }

        public EventoDto ObtenerPorId(long id)
        {
            var evento = _eventoRepositorio.GetById(id);

            if(evento == null) throw new Exception("No se encontro el registro solicitado.");

            return new EventoDto()
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Descripcion = evento.Descripcion,
                Mail = evento.Mail,
                TipoEventoId = evento.TipoEventoId,
                Imagen = evento.Imagen
            };
        }

        public void Insertar(EventoDto dto)
        {
            var evento = new Dominio.Entity.Entidades.Evento()
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Mail = dto.Mail,
                TipoEventoId = dto.TipoEventoId,
                Imagen = dto.Imagen
            };

            _eventoRepositorio.Add(evento);
            Guardar();
        }

        public void Modificar(EventoDto dto)
        {
            var evento = _eventoRepositorio.GetById(dto.Id);

            if (evento == null) throw new Exception("No se encontro el registro solicitado.");

            evento.Titulo = dto.Titulo;
            evento.Descripcion = dto.Descripcion;
            evento.Mail = dto.Mail;
            evento.TipoEventoId = dto.TipoEventoId;
            evento.Imagen = dto.Imagen;

            _eventoRepositorio.Update(evento);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var evento = _eventoRepositorio.GetById(id);

            if (evento == null) throw new Exception("No se encontro el registro solicitado.");

            _eventoRepositorio.Delete(id);
            Guardar();
        }

        public IEnumerable<EventoDto> ObtenerEventosPorTipoEventoId(long tipoEventoId)
        {

            var eventos = _eventoRepositorio.GetByFilter(x => x.TipoEventoId == tipoEventoId).Select(x => new EventoDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                Mail = x.Mail,
                TipoEventoId = x.TipoEventoId,
                Imagen = x.Imagen

            }).ToList();

            if (eventos == null) throw new Exception("No se encontro el registro solicitado.");

            return eventos;

        }

        public void Guardar()
        {
            _eventoRepositorio.Save();
        }
    }
}
