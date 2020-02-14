using System;
using System.Collections.Generic;
using EM.Dominio.Repositorio.Fecha;
using EM.Infraestructura.Repositorio.Fecha;
using EM.IServicio.Fecha;
using EM.IServicio.Fecha.DTOs;

namespace EM.Servicio.Fecha
{
    public class FechaServicio : IFechaServicio
    {
        private readonly IFechaRepositorio _fechaRepositorio = new FechaRepositorio();


        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _fechaRepositorio.Save();
        }

        public FechaDto Insertar(FechaDto dto)
        {
            var Fecha = new Dominio.Entity.Entidades.Fecha()
            {
                FechaEvento = dto.FechaEvento,
                HoraCierre = dto.HoraCierre,
                HoraInicio = dto.HoraInicio
            };

            _fechaRepositorio.Add(Fecha);
            Guardar();

            dto.Id = Fecha.Id;
            return dto;
        }

        public FechaDto Modificar(FechaDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FechaDto> Obtener()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FechaDto> ObtenerPorFiltro(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entity.Entidades.Fecha ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
