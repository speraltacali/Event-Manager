using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.Entidades;
using EM.Dominio.Repositorio.FechaEvento;
using EM.Infraestructura.Repositorio.FechaEvento;
using EM.IServicio.FechaEvento;
using EM.IServicio.FechaEvento.DTOs;

namespace EM.Servicio.FechaEvento
{
    public class FechaEventoServicio : IFechaEventoServicio
    {
        private readonly  IFechaEventoRepositorio _fechaEventoRepositorio = new FechaEventoRepositorio();

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _fechaEventoRepositorio.Save();
        }

        public FechaEventoDto Insertar(FechaEventoDto dto)
        {
            var FechaEvento = new Dominio.Entity.Entidades.FechaEvento
            {
                FechaId = dto.FechaId,
                EventosId = dto.EventosId
            };

            _fechaEventoRepositorio.Add(FechaEvento);
            Guardar();

            dto.Id = FechaEvento.Id;
            return dto;
        }

        public FechaEventoDto ObtenerPorIdEvento(long idEvento)
        {
            var fecha = _fechaEventoRepositorio.GetByFilter(x => x.EventosId == idEvento).Select(x => new FechaEventoDto
            {
                EventosId = x.EventosId,
                FechaId = x.FechaId,
                Id = x.Id
            });

            var aux = fecha.FirstOrDefault(x => x.EventosId == idEvento);

            return aux;
        }

        public FechaEventoDto Modificar(FechaEventoDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FechaEventoDto> Obtener()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FechaEventoDto> ObtenerPorFiltro(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public FechaEventoDto ObtenerPorId(long id)
        {
            var fecha = _fechaEventoRepositorio.GetById(id);

            var aux = new FechaEventoDto
            {
                EventosId = fecha.EventosId,
                FechaId = fecha.FechaId,
                Id = fecha.Id
            };

            return aux;
        }
    }
}
