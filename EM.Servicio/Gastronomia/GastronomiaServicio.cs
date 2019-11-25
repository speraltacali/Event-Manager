using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Gastronomia;
using EM.IServicio.Gastronomia;
using EM.IServicio.Gastronomia.DTOs;

namespace EM.Servicio.Gastronomia
{
    public class GastronomiaServicio : IGastronomiaServicio
    {
        private readonly IGastronomiaRepositorio _gastronomiaRepositorio;

        public GastronomiaServicio(IGastronomiaRepositorio gastronomiaRepositorio)
        {
            _gastronomiaRepositorio = gastronomiaRepositorio;
        }

        public IEnumerable<GastronomiaDto> ObtenerTodo()
        {
            return _gastronomiaRepositorio.GetAll()
                .Select(x => new GastronomiaDto()
                {
                    Id = x.Id,
                    LugarId = x.LugarId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public IEnumerable<GastronomiaDto> Obtener(string cadenaBuscar)
        {
            return _gastronomiaRepositorio.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar)
                                                            || x.Lugar.Descripcion.Contains(cadenaBuscar))
                .Select(x => new GastronomiaDto()
                {
                    Id = x.Id,
                    LugarId = x.LugarId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public GastronomiaDto ObtenerPorId(long id)
        {
            var gastronomia = _gastronomiaRepositorio.GetById(id);

            if (gastronomia == null) throw new Exception("No se encontro datos solicitados");

            return new GastronomiaDto()
            {
                Id = gastronomia.Id,
                LugarId = gastronomia.LugarId,
                Descripcion = gastronomia.Descripcion
            };
        }

        public void Insertar(GastronomiaDto dto)
        {
            var gastronomia = new Dominio.Entity.Entidades.Gastronomia()
            {
                Id = dto.Id,
                LugarId = dto.LugarId,
                Descripcion = dto.Descripcion
            };

            _gastronomiaRepositorio.Add(gastronomia);
            Guardar();
        }

        public void Modificar(GastronomiaDto dto)
        {
            var gastronomia = _gastronomiaRepositorio.GetById(dto.Id);

            if (gastronomia == null) throw new Exception("No se encontro datos solicitados");

            gastronomia.LugarId = dto.LugarId;
            gastronomia.Descripcion = dto.Descripcion;

            _gastronomiaRepositorio.Update(gastronomia);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var gastronomia = _gastronomiaRepositorio.GetById(id);

            if (gastronomia == null) throw new Exception("No se encontro datos solicitados");

            _gastronomiaRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _gastronomiaRepositorio.Save();
        }
    }
}
