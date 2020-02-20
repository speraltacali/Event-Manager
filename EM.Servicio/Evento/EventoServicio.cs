using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EM.Dominio.Entity.Enum;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.Evento;
using EM.Dominio.Repositorio.Fecha;
using EM.Dominio.Repositorio.FechaEvento;
using EM.Infraestructura.Repositorio.Evento;
using EM.Infraestructura.Repositorio.Fecha;
using EM.Infraestructura.Repositorio.FechaEvento;
using EM.IServicio.Evento;
using EM.IServicio.Evento.DTOs;
using EM.IServicio.EventoLugar.DTOs;

namespace EM.Servicio.Evento
{
    public class EventoServicio : IEventoServicio
    {
        private readonly IEventoRepositorio _eventoRepositorio = new EventoRepositorio();
        private readonly IFechaEventoRepositorio _fechaEventoRepositorio = new FechaEventoRepositorio();
        private readonly IFechaRepositorio _fechaRepositorio = new FechaRepositorio();

        public IEnumerable<EventoDto> ObtenerTodo()
        {
            return _eventoRepositorio.GetAll()
                .Where(x=>x.Estado == EventoEstado.Activo)
                .Select(x => new EventoDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Mail = x.Mail,
                    TipoEventoId = x.TipoEventoId,
                    Orante = x.Orante,
                    Organizacion = x.Organizacion,
                    Latitud = x.Latitud,
                    Longitud = x.Longitud,
                    Domicilio = x.Domicilio,
                    Telefono = x.Telefono,
                    Imagen = x.Imagen,
                    Estado = x.Estado
                }).ToList();
        }

        public IEnumerable<EventoDto> Obtener(string cadenaBuscar)
        {
            return _eventoRepositorio.GetByFilter(x=>x.Descripcion.Contains(cadenaBuscar)
            || x.TiposEventos.Descripcion.Contains(cadenaBuscar)
            || x.Estado == EventoEstado.Activo
            || x.Titulo.Contains(cadenaBuscar))
                .Select(x => new EventoDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Mail = x.Mail,
                    TipoEventoId = x.TipoEventoId,
                    Orante = x.Orante,
                    Organizacion = x.Organizacion,
                    Latitud = x.Latitud,
                    Longitud = x.Longitud,
                    Domicilio = x.Domicilio,
                    Telefono = x.Telefono,
                    Imagen = x.Imagen,
                    Estado = x.Estado
                }).ToList();
        }

        public EventoDto ObtenerPorTitulo(string cadenaBuscar)
        {
            var lista = _eventoRepositorio.GetByFilter(x => x.Titulo.Contains(cadenaBuscar)
                                                            || x.Estado == EventoEstado.Activo)
                .Select(x => new EventoDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Mail = x.Mail,
                    TipoEventoId = x.TipoEventoId,
                    Orante = x.Orante,
                    Organizacion = x.Organizacion,
                    Latitud = x.Latitud,
                    Longitud = x.Longitud,
                    Domicilio = x.Domicilio,
                    Telefono = x.Telefono,
                    Imagen = x.Imagen,
                    Estado = x.Estado
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
                Orante = evento.Orante,
                Organizacion = evento.Organizacion,
                Latitud = evento.Latitud,
                Longitud = evento.Longitud,
                Domicilio = evento.Domicilio,
                Telefono = evento.Telefono,
                Imagen = evento.Imagen,
                Estado = evento.Estado
            };
        }

        public EventoDto Insertar(EventoDto dto)
        {
            var evento = new Dominio.Entity.Entidades.Evento()
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Mail = dto.Mail,
                TipoEventoId = dto.TipoEventoId,
                Orante = dto.Orante,
                Organizacion = dto.Organizacion,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                Domicilio = dto.Domicilio,
                Telefono = dto.Telefono,
                Imagen = dto.Imagen,
                Estado = EventoEstado.Activo
            };

            _eventoRepositorio.Add(evento);
            Guardar();

            dto.Id = evento.Id;
            return dto;
        }

        public EventoDto Modificar(EventoDto dto)
        {
            var evento = _eventoRepositorio.GetById(dto.Id);

            if (evento == null) throw new Exception("No se encontro el registro solicitado.");

            evento.Titulo = dto.Titulo;
            evento.Descripcion = dto.Descripcion;
            evento.Mail = dto.Mail;
            evento.TipoEventoId = dto.TipoEventoId;
            evento.Imagen = dto.Imagen;
            evento.Orante = dto.Orante;
            evento.Organizacion = dto.Organizacion;
            evento.Telefono = dto.Telefono;

            _eventoRepositorio.Update(evento);
            Guardar();

            dto.Id = evento.Id;
            return dto;
        }

        public EventoDto ModificarEventoLocalizacion(EventoDto dto)
        {
            var evento = _eventoRepositorio.GetById(dto.Id);

            if (evento == null) throw new Exception("No se encontro el registro solicitado.");

            evento.Domicilio = dto.Domicilio;
            evento.Longitud = dto.Longitud;
            evento.Latitud = dto.Latitud;

            _eventoRepositorio.Update(evento);
            Guardar();

            dto.Id = evento.Id;
            return dto;
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
                Orante = x.Orante,
                Organizacion = x.Organizacion,
                Latitud = x.Latitud,
                Longitud = x.Longitud,
                Domicilio = x.Domicilio,
                Telefono = x.Telefono,
                Imagen = x.Imagen

            }).ToList();

            if (eventos == null) throw new Exception("No se encontro el registro solicitado.");

            return eventos;

        }

        public void Guardar()
        {
            _eventoRepositorio.Save();
        }

        //*********************** Cambiar de Estado *********************

        public void EstadoActivo(long id)
        {
            var Estado = _eventoRepositorio.GetById(id);

            Estado.Estado = EventoEstado.Activo;

            _eventoRepositorio.Update(Estado);
            Guardar();
        }

        public void EstadoSuspendido(long id)
        {
            var Estado = _eventoRepositorio.GetById(id);

            Estado.Estado = EventoEstado.Suspendido;

            _eventoRepositorio.Update(Estado);
            Guardar();
        }

        public void EstadoVencido(long id)
        {
            var Estado = _eventoRepositorio.GetById(id);

            Estado.Estado = EventoEstado.Vencido;

            _eventoRepositorio.Update(Estado);
            Guardar();
        }



        //************************ Validaciones *************************


        public bool ValidarTitulo(string Titulo)
        {
            var titulo = _eventoRepositorio.GetByFilter(x => x.Titulo == Titulo).ToList();

            if(titulo.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarFecha(DateTime fecha)
        {
            if(fecha <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
