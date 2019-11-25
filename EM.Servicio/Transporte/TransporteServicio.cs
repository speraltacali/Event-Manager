using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Transporte;
using EM.IServicio.Transporte;
using EM.IServicio.Transporte.DTOs;

namespace EM.Servicio.Transporte
{
    public class TransporteServicio : ITransporteServicio
    {

        private readonly ITransporteRepositorio _transporteRepositorio;

        public TransporteServicio(ITransporteRepositorio transporteRepositorio)
        {
            _transporteRepositorio = transporteRepositorio;
        }

        public IEnumerable<TransporteDto> ObtenerTodo()
        {
            return _transporteRepositorio.GetAll()
                .Select(x => new TransporteDto()
                {
                    Id = x.Id,
                    LugarId = x.LugarId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public IEnumerable<TransporteDto> Obtener(string cadenaBuscar)
        {
            return _transporteRepositorio.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar)
                                                            || x.Lugar.Descripcion.Contains(cadenaBuscar))
                .Select(x => new TransporteDto()
                {
                    Id = x.Id,
                    LugarId = x.LugarId,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public TransporteDto ObtenerPorId(long id)
        {
            var gastronomia = _transporteRepositorio.GetById(id);

            if (gastronomia == null) throw new Exception("No se encontro datos solicitados");

            return new TransporteDto()
            {
                Id = gastronomia.Id,
                LugarId = gastronomia.LugarId,
                Descripcion = gastronomia.Descripcion
            };
        }

        public void Insertar(TransporteDto dto)
        {
            var gastronomia = new Dominio.Entity.Entidades.Transporte()
            {
                Id = dto.Id,
                LugarId = dto.LugarId,
                Descripcion = dto.Descripcion
            };

            _transporteRepositorio.Add(gastronomia);
            Guardar();
        }

        public void Modificar(TransporteDto dto)
        {
            var gastronomia = _transporteRepositorio.GetById(dto.Id);

            if (gastronomia == null) throw new Exception("No se encontro datos solicitados");

            gastronomia.LugarId = dto.LugarId;
            gastronomia.Descripcion = dto.Descripcion;

            _transporteRepositorio.Update(gastronomia);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var gastronomia = _transporteRepositorio.GetById(id);

            if (gastronomia == null) throw new Exception("No se encontro datos solicitados");

            _transporteRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _transporteRepositorio.Save();
        }
    }
}
