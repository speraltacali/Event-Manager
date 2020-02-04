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

        public IEnumerable<OcupacionDto> Obtener()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OcupacionDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entity.Entidades.Ocupacion ObtenerPorId(long id)
        {
            return _repositorio.GetById(id);
        }

        public void Agregar(OcupacionDto dto)
        {
            var ocupacion = new Dominio.Entity.Entidades.Ocupacion
            {
                Descripcion = dto.Descripcion
            };
            _repositorio.Add(ocupacion);
            Guardar();
        }

        public void Modificar(OcupacionDto dto)
        {
            var ocupacion = ObtenerPorId(dto.Id);
            
            ocupacion.Descripcion = dto.Descripcion;
            _repositorio.Update(ocupacion);
            Guardar();
        }

        public void Eliminar(long id)
        {
            _repositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _repositorio.Save();
        }
    }
}
