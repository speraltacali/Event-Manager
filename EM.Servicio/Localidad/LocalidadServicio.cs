using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Localidad;
using EM.IServicio.Localidad;
using EM.IServicio.Localidad.DTOs;

namespace EM.Servicio.Localidad
{
    public class LocalidadServicio : ILocalidadServicio
    {
        private readonly ILocalidadRepositorio _localidadRepositorio;

        public LocalidadServicio(ILocalidadRepositorio localidadRepositorio)
        {
            _localidadRepositorio = localidadRepositorio;
        }

        public IEnumerable<LocalidadDto> ObtenerTodo()
        {
            return _localidadRepositorio.GetAll()
                .Select(x => new LocalidadDto()
                {
                    Id = x.Id,
                    ProvinciaId = x.ProvinciaId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public IEnumerable<LocalidadDto> Obtener(string cadenaBuscar)
        {
            return _localidadRepositorio.GetAll(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new LocalidadDto()
                {
                    Id = x.Id,
                    ProvinciaId = x.ProvinciaId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public LocalidadDto ObtenerPorId(long id)
        {
            var localidad = _localidadRepositorio.GetById(id);

            if(localidad == null) throw  new Exception("No se encontro el registro solicitado.");

            return new LocalidadDto()
            {
                Id = localidad.Id,
                ProvinciaId = localidad.ProvinciaId,
                Descripcion = localidad.Descripcion
            };
        }

        public void Insertar(LocalidadDto dto)
        {
            var localiadad = new Dominio.Entity.Entidades.Localidad()
            {
                ProvinciaId = dto.ProvinciaId,
                Descripcion = dto.Descripcion
            }; 

            _localidadRepositorio.Add(localiadad);

        }

        public void Modificar(LocalidadDto dto)
        {
            var localidad = _localidadRepositorio.GetById(dto.Id);

            if (localidad == null) throw new Exception("No se encontro el registro solicitado.");

            localidad.Descripcion = dto.Descripcion;
            localidad.ProvinciaId = dto.ProvinciaId;

            _localidadRepositorio.Update(localidad);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var localidad = _localidadRepositorio.GetById(id);

            if (localidad == null) throw new Exception("No se encontro el registro solicitado.");

            _localidadRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _localidadRepositorio.Save();
        }
    }
}
