using EM.Dominio.Entity.Entidades;
using EM.Dominio.Repositorio.TipoEvento;
using EM.Infraestructura.Repositorio.TipoEvento;
using EM.IServicio.TipoEvento;
using EM.IServicio.TipoEvento.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Servicio.TipoEvento
{
    public class TipoEventoServicio : ITipoEventoServicio
    {
        private readonly ITipoEventoRepositorio tipoEventoServicio;

        public TipoEventoServicio()
        {
            tipoEventoServicio = new TipoEventoRepositorio();
        }

        public void Delete(long id)
        {
            tipoEventoServicio.Delete(id);

            tipoEventoServicio.Save();
        }

        public IEnumerable<TipoEventoDto> Get()
        {
            return tipoEventoServicio.GetAll().Select(x => new TipoEventoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion
            }).ToList();
        }

        public IEnumerable<TipoEventoDto> GetByFilter(string cadenaBuscar)
        {
            return tipoEventoServicio.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new TipoEventoDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion
                })
                .ToList();
        }

        public Dominio.Entity.Entidades.TipoEvento GetById(long id)
        {
            return tipoEventoServicio.GetById(id);
        }

        public void Insert(TipoEventoDto dto)
        {
            var tipo = new Dominio.Entity.Entidades.TipoEvento
            {
               Descripcion = dto.Descripcion
            };

            tipoEventoServicio.Add(tipo);

            tipoEventoServicio.Save();

        }

        public TipoEventoDto ObtenerId(long id)
        {
            var tipo = tipoEventoServicio.GetById(id);

            return new TipoEventoDto
            {
                Descripcion = tipo.Descripcion,
                Id = tipo.Id
            };
        }

        public void Save()
        {
            tipoEventoServicio.Save();
        }

        public void Update(TipoEventoDto dto)
        {
            var tipo = tipoEventoServicio.GetById(dto.Id);

            tipo.Descripcion = dto.Descripcion;

            tipoEventoServicio.Update(tipo);
            tipoEventoServicio.Save();

        }
    }
}
