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
        private readonly ITipoEventoRepositorio _tipoEventoServicio = new TipoEventoRepositorio();


        public void Delete(long id)
        {
            _tipoEventoServicio.Delete(id);

            _tipoEventoServicio.Save();
        }

        public IEnumerable<TipoEventoDto> Get()
        {
            return _tipoEventoServicio.GetAll().Select(x => new TipoEventoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion
            }).ToList();
        }

        public IEnumerable<TipoEventoDto> GetByFilter(string cadenaBuscar)
        {
            return _tipoEventoServicio.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new TipoEventoDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion
                })
                .ToList();
        }

        public Dominio.Entity.Entidades.TipoEvento GetById(long id)
        {
            return _tipoEventoServicio.GetById(id);
        }

        public void Insert(TipoEventoDto dto)
        {
            var tipo = new Dominio.Entity.Entidades.TipoEvento
            {
               Descripcion = dto.Descripcion
            };

            _tipoEventoServicio.Add(tipo);

            _tipoEventoServicio.Save();

        }

        public TipoEventoDto ObtenerId(long id)
        {
            var tipo = _tipoEventoServicio.GetById(id);

            return new TipoEventoDto
            {
                Descripcion = tipo.Descripcion,
                Id = tipo.Id
            };
        }

        public void Save()
        {
            _tipoEventoServicio.Save();
        }

        public void Update(TipoEventoDto dto)
        {
            var tipo = _tipoEventoServicio.GetById(dto.Id);

            tipo.Descripcion = dto.Descripcion;

            _tipoEventoServicio.Update(tipo);
            _tipoEventoServicio.Save();

        }

        //****************************** Insert Por Defecto ****************************//

        public void InsertarPorDefecto()
        {
            var validar = _tipoEventoServicio.GetAll().Any();

            if (!validar)
            {
                Insert(new TipoEventoDto()
                {
                    Descripcion = "Ciencia y Tecnologia"
                });

                Insert(new TipoEventoDto()
                {
                    Descripcion = "Deporte"
                });

                Insert(new TipoEventoDto()
                {
                    Descripcion = "Robotica"
                });

                Insert(new TipoEventoDto()
                {
                    Descripcion = "Arte"
                });

                Insert(new TipoEventoDto()
                {
                    Descripcion = "Politica"
                });

            }
        }
    }
}
