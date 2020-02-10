using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Lugar;
using EM.IServicio.Lugar;
using EM.IServicio.Lugar.DTOs;

namespace EM.Servicio.Lugar
{
    public class LugarServicio : ILugarServicio
    {
        private readonly ILugarRepositorio _lugarRepositorio;

        public LugarServicio(ILugarRepositorio lugarRepositorio)
        {
            _lugarRepositorio = lugarRepositorio;
        }

        public IEnumerable<LugarDto> ObtenerTodo()
        {
            return _lugarRepositorio.GetAll()
                .Select(x => new LugarDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    DomicilioId = x.DomicilioId
                }).ToList();
        }

        public IEnumerable<LugarDto> Obtener(string cadenaBuscar)
        {
            return _lugarRepositorio.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar)
                                                      || x.Domicilio.Descripción.Contains(cadenaBuscar))
                .Select(x => new LugarDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    DomicilioId = x.DomicilioId
                }).ToList();
        }

        public LugarDto ObtenerPorId(long id)
        {
            var lugar = _lugarRepositorio.GetById(id);

            if (lugar == null) throw new Exception("No se encontro el registro solicitado.");

            return new LugarDto()
            {
                Id = lugar.Id,
                Descripcion = lugar.Descripcion,
                DomicilioId = lugar.DomicilioId
            };
        }

        public void Insertar(LugarDto dto)
        {
            var lugar = new Dominio.Entity.Entidades.Lugar()
            {
                Descripcion = dto.Descripcion,
                DomicilioId = dto.DomicilioId
            };

            _lugarRepositorio.Add(lugar);
            Guardar();
        }

        public void Modificar(LugarDto dto)
        {
            var lugar = _lugarRepositorio.GetById(dto.Id);

            if(lugar == null) throw new Exception("No se encontro el registro solicitado.");

            lugar.Descripcion = dto.Descripcion;
            lugar.DomicilioId = dto.DomicilioId;

            _lugarRepositorio.Update(lugar);
            Guardar();

        }

        public void Eliminar(long id)
        {
            var lugar = _lugarRepositorio.GetById(id);

            if (lugar == null) throw new Exception("No se encontro el registro solicitado.");

            _lugarRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _lugarRepositorio.Save();
        }
    }
}
