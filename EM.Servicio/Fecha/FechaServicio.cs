using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.Entidades;
using EM.Dominio.Repositorio.Fecha;
using EM.Dominio.Repositorio.FechaEvento;
using EM.Infraestructura.Repositorio.Fecha;
using EM.Infraestructura.Repositorio.FechaEvento;
using EM.IServicio.Fecha;
using EM.IServicio.Fecha.DTOs;

namespace EM.Servicio.Fecha
{
    public class FechaServicio : IFechaServicio
    {
        private readonly IFechaRepositorio _fechaRepositorio = new FechaRepositorio();
        private readonly IFechaEventoRepositorio _fechaEventoRepositorio = new FechaEventoRepositorio();


        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _fechaRepositorio.Save();
        }

        public void Insertar(FechaDto dto)
        {
            var InsertarFecha = new Dominio.Entity.Entidades.Fecha()
            {
                FechaCierre = dto.FechaCierre,
                FechaInicio = dto.FechaInicio
            };

        }

        public void Modificar(FechaDto dto)
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
