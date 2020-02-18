using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.CreadorEvento;
using EM.Infraestructura.Repositorio.CreadorEvento;
using EM.IServicio.CreadorEvento;
using EM.IServicio.CreadorEvento.DTO;
using EM.IServicio.Evento.DTOs;

namespace EM.Servicio.CreadorEvento
{
    public class CreadorEventoServicio : ICreadorEventoServicio
    {
        private readonly ICreadorEventoRepositorio _creadorEventoRepositorio = new CreadorEventoRepositorio();

        public IEnumerable<CreadorEventoDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreadorEventoDto> Obtener(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public CreadorEventoDto ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(CreadorEventoDto dto)
        {
            var UserEvento = new Dominio.Entity.Entidades.CreadorEvento()
            {
                EventoId = dto.EventoId,
                UsuarioId = dto.UsuarioId,
                Fecha = dto.Fecha
            };

            _creadorEventoRepositorio.Add(UserEvento);
            Guardar();
        }

        public void Modificar(CreadorEventoDto dto)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _creadorEventoRepositorio.Save();
        }

        public IEnumerable<EventoDto> ObtenerPorCreador(long id)
        {
            var Validar = _creadorEventoRepositorio.GetAll().Any();

            if(Validar)
            {
                return _creadorEventoRepositorio.GetByFilter(x => x.UsuarioId == id)
                    .Select(x => new CreadorEventoDto()
                    {
                        EventoId = 
                    }).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
