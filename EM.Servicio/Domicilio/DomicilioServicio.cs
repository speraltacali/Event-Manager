using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Domicilio;
using EM.Dominio.Repositorio.Localidad;
using EM.IServicio.Domicilio;
using EM.IServicio.Domicilio.DTOs;

namespace EM.Servicio.Domicilio
{
    public class DomicilioServicio : IDomicilioServicio
    {
        private readonly IDomicilioRepositorio _domicilioRepositorio;
        private readonly ILocalidadRepositorio _localidadRepositorio;

        public DomicilioServicio(IDomicilioRepositorio domicilioRepositorio , ILocalidadRepositorio localidadRepositorio)
        {
            _domicilioRepositorio = domicilioRepositorio;
            _localidadRepositorio = localidadRepositorio;
        }

        public IEnumerable<DomicilioDto> ObtenerTodo()
        {
            return _domicilioRepositorio.GetAll()
                .Select(x => new DomicilioDto()
                {
                    Id = x.Id,
                    LocalidadId = x.LocalidadId,
                    Descripción = x.Descripción
                }).ToList();
        }

        public IEnumerable<DomicilioDto> Obtener(string cadenaBuscar)
        {
            return _domicilioRepositorio.GetByFilter(x => x.Descripción.Contains(cadenaBuscar)
                                                          || x.Localidades.Descripcion.Contains(cadenaBuscar))
                .Select(x => new DomicilioDto()
                {
                    Id = x.Id,
                    LocalidadId = x.LocalidadId,
                    Descripción = x.Descripción
                }).ToList();
        }

        public DomicilioDto ObtenerPotId(long id)
        {
            var domicilio = _domicilioRepositorio.GetById(id);

            if (domicilio == null) throw new Exception("No se encontro el registro solicitado.");

            return  new DomicilioDto()
            {
                Id = domicilio.Id,
                LocalidadId = domicilio.LocalidadId,
                Descripción = domicilio.Descripción
            };
        }

        public void Insertar(DomicilioDto dto)
        {
            var domicilio = new Dominio.Entity.Entidades.Domicilio
            {
                LocalidadId = _localidadRepositorio.GetById(dto.LocalidadId).Id,
                Descripción = dto.Descripción
            };

            _domicilioRepositorio.Add(domicilio);
            Guardar();
        }

        public void Modificar(DomicilioDto dto)
        {
            var domicilio = _domicilioRepositorio.GetById(dto.Id);

            if(domicilio == null)throw new Exception("No se encontro el registro solicitado.");

            domicilio.LocalidadId = dto.LocalidadId;
            domicilio.Descripción = dto.Descripción;

            _domicilioRepositorio.Update(domicilio);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var domicilio = _domicilioRepositorio.GetById(id);

            if (domicilio == null) throw new Exception("No se encontro el registro solicitado.");

            _domicilioRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _domicilioRepositorio.Save();
        }
    }

}
