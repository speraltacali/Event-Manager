using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Alojamiento;
using EM.IServicio.Alojamiento;
using EM.IServicio.Alojamiento.DTOs;

namespace EM.Servicio.Alojamiento
{
    public class AlojamientoServicio : IAlojamientoServicio
    {
        private readonly IAlojamientoRepositorio _alojamientoRepositorio;

        public AlojamientoServicio(IAlojamientoRepositorio alojamientoRepositorio)
        {
            _alojamientoRepositorio = alojamientoRepositorio;
        }

        public IEnumerable<AlojamientoDto> ObtenerTodo()
        {
            return _alojamientoRepositorio.GetAll()
                .Select(x => new AlojamientoDto()
                {
                    Id = x.Id,
                    LugarId = x.LugarId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public IEnumerable<AlojamientoDto> Obtener(string cadenaBuscar)
        {
            return _alojamientoRepositorio.GetByFilter(x=>x.Descripcion.Contains(cadenaBuscar)
            || x.Lugares.Descripcion.Contains(cadenaBuscar))
                .Select(x => new AlojamientoDto()
                {
                    Id = x.Id,
                    LugarId = x.LugarId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public AlojamientoDto ObtenerPorId(long id)
        {
            var alojamiento = _alojamientoRepositorio.GetById(id);

            if(alojamiento == null) throw new Exception("No se encontro datos solicitados");

            return new AlojamientoDto()
            {
                Id = alojamiento.Id,
                LugarId = alojamiento.LugarId,
                Descripcion = alojamiento.Descripcion
            };
        }

        public void Insertar(AlojamientoDto dto)
        {
            var alojamiento = new Dominio.Entity.Entidades.Alojamiento()
            {
                Id = dto.Id,
                LugarId = dto.LugarId,
                Descripcion = dto.Descripcion
            };

            _alojamientoRepositorio.Add(alojamiento);
            Guardar();
        }

        public void Modificar(AlojamientoDto dto)
        {
            var alojamiento = _alojamientoRepositorio.GetById(dto.Id);

            if (alojamiento == null) throw new Exception("No se encontro datos solicitados");

            alojamiento.LugarId = dto.LugarId;
            alojamiento.Descripcion = dto.Descripcion;

            _alojamientoRepositorio.Update(alojamiento);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var alojamiento = _alojamientoRepositorio.GetById(id);

            if (alojamiento == null) throw new Exception("No se encontro datos solicitados");

            _alojamientoRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _alojamientoRepositorio.Save();
        }
    }
}
