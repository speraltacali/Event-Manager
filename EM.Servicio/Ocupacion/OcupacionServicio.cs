using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Ocupacion;
using EM.IServicio.Ocupacion;
using EM.IServicio.Ocupacion.DTOs;

namespace EM.Servicio.Ocupacion
{
    public class OcupacionServicio : IOcupacionServicio
    {
        private readonly IOcupacionRepositorio _repositorio;

        public OcupacionServicio(IOcupacionRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<OcupacionDto> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OcupacionDto> GetByFilter(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entity.Entidades.Ocupacion GetById(long id)
        {
            return _repositorio.GetById(id);
        }

        public void Insert(OcupacionDto dto)
        {
            var ocupacion = new Dominio.Entity.Entidades.Ocupacion
            {
                Descripcion = dto.Descripcion
            };
            _repositorio.Add(ocupacion);
            Save();
        }

        public void Update(OcupacionDto dto)
        {
            var ocupacion = GetById(dto.Id);
            
            ocupacion.Descripcion = dto.Descripcion;
            _repositorio.Update(ocupacion);
            Save();
        }

        public void Delete(long id)
        {
            _repositorio.Delete(id);
            Save();
        }

        public void Save()
        {
            _repositorio.Save();
        }
    }
}
