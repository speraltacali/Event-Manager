using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Sala;
using EM.IServicio.Sala;
using EM.IServicio.Sala.DTOs;

namespace EM.Servicio.Sala
{
    public class SalaServicio : ISalaServicio
    {
        private readonly ISalaRepositorio _salaRepositorio;

        public SalaServicio(ISalaRepositorio salaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
        }

        public IEnumerable<SalaDto> ObtenerTodo()
        {
            return _salaRepositorio.GetAll()
                .Select(x => new SalaDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Capacidad = x.Capacidad,
                    LugarId = x.LugarId
                }).ToList();
        }

        public IEnumerable<SalaDto> Obtener(string cadenaBuscar)
        {
            return _salaRepositorio.GetAll(x => x.Descripcion.Contains(cadenaBuscar)
                                                || x.Lugar.Descripcion.Contains(cadenaBuscar))
                .Select(x => new SalaDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Capacidad = x.Capacidad,
                    LugarId = x.LugarId
                }).ToList();
        }

        public SalaDto ObtenerPorId(long id)
        {
            var sala = _salaRepositorio.GetById(id);

            if(sala == null) throw new Exception("No se encontro el registro solicitado.");

            return new SalaDto()
            {
                Id = sala.Id,
                LugarId = sala.LugarId,
                Descripcion = sala.Descripcion,
                Capacidad = sala.Capacidad
            };
        }

        public void Insertar(SalaDto dto)
        {
            var sala = new Dominio.Entity.Entidades.Sala()
            {
                Id = dto.Id,
                LugarId = dto.LugarId,
                Descripcion = dto.Descripcion,
                Capacidad = dto.Capacidad
            };

            _salaRepositorio.Add(sala);
            Guardar();
        }

        public void Modificar(SalaDto dto)
        {
            var sala = _salaRepositorio.GetById(dto.Id);

            if (sala == null) throw new Exception("No se encontro el registro solicitado.");

            sala.LugarId = dto.LugarId;
            sala.Descripcion = dto.Descripcion;
            sala.Capacidad = dto.Capacidad;

            _salaRepositorio.Update(sala);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var sala = _salaRepositorio.GetById(id);

            if (sala == null) throw new Exception("No se encontro el registro solicitado.");

            _salaRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _salaRepositorio.Save();
        }
    }
}
