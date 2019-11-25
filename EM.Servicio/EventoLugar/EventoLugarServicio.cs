using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.EventoLugar;
using EM.IServicio.EventoLugar;
using EM.IServicio.EventoLugar.DTOs;

namespace EM.Servicio.EventoLugar
{
    public class EventoLugarServicio : IEventoLugarServicio
    {
        private readonly IEventoLugarRepositorio _eventoLugarRepositorio;

        public EventoLugarServicio(IEventoLugarRepositorio eventoLugarRepositorio)
        {
            _eventoLugarRepositorio = eventoLugarRepositorio;
        }

        public IEnumerable<EventoLugarDto> ObtenerTodo()
        {
            return _eventoLugarRepositorio.GetAll()
                .Select(x => new EventoLugarDto()
                {
                    Id = x.Id,
                    EventoId = x.EventoId,
                    LugarId = x.LugarId
                }).ToList();
        }

        public IEnumerable<EventoLugarDto> Obtener(string cadenaBuscar)
        {
            return _eventoLugarRepositorio.GetByFilter(x=>x.Evento.Descripcion.Contains(cadenaBuscar)
            || x.Lugar.Descripcion.Contains(cadenaBuscar))
                .Select(x => new EventoLugarDto()
                {
                    Id = x.Id,
                    EventoId = x.EventoId,
                    LugarId = x.LugarId
                }).ToList();
        }

        public EventoLugarDto ObtenerPorId(long id)
        {
            var eventoLugar = _eventoLugarRepositorio.GetById(id);

            if(eventoLugar == null)throw new Exception("No se encontro el registro solicitado.");

            return new EventoLugarDto()
            {
                Id = eventoLugar.Id,
                LugarId = eventoLugar.LugarId,
                EventoId = eventoLugar.EventoId
            };
        }

        public void Insertar(EventoLugarDto dto)
        {
            var eventoLugar = new Dominio.Entity.Entidades.EventoLugar()
            {
                EventoId = dto.EventoId,
                LugarId = dto.LugarId,
            };

            _eventoLugarRepositorio.Add(eventoLugar);
            Guardar();
        }

        public void Modificar(EventoLugarDto dto)
        {
            var eventoLugar = _eventoLugarRepositorio.GetById(dto.Id);

            if (eventoLugar == null) throw new Exception("No se encontro el registro solicitado.");

            eventoLugar.EventoId = dto.EventoId;
            eventoLugar.LugarId = dto.LugarId;

            _eventoLugarRepositorio.Update(eventoLugar);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var eventoLugar = _eventoLugarRepositorio.GetById(id);

            if (eventoLugar == null) throw new Exception("No se encontro el registro solicitado.");

            _eventoLugarRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _eventoLugarRepositorio.Save();
        }
    }
}
