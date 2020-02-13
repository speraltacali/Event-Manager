using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.CondicionIva;
using EM.Infraestructura.Repositorio.CondicionIva;
using EM.IServicio.CondicionIva;
using EM.IServicio.CondicionIva.DTOs;

namespace EM.Servicio.CondicionIva
{
    public class CondicionIvaServicio : ICondicionIvaServicio
    {

        private readonly ICondicionIvaRepositorio _condicionIvaRepositorio = new CondicionIvaRepositorio();

        public void Insertar(CondicionIvaDto iva)
        {
            _condicionIvaRepositorio.Add(new Dominio.Entity.Entidades.CondicionIva()
            {
                Codigo = ObtenerCodigo(),
                Descripcion = iva.Descripcion,
                Eliminado = false
            });

            _condicionIvaRepositorio.Save();
        }

        public void Modificar(CondicionIvaDto iva)
        {
            var update = _condicionIvaRepositorio.GetById(iva.Id);

            if (update == null) throw new Exception("No se encontro datos solicitados");

            _condicionIvaRepositorio.Update(new Dominio.Entity.Entidades.CondicionIva()
            {
                Codigo = iva.Codigo,
                Descripcion = iva.Descripcion,
                Eliminado = iva.Eliminado
            });

            _condicionIvaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var delete = _condicionIvaRepositorio.GetById(id);

            if (delete == null) throw new Exception("No se encontro datos solicitados");

            _condicionIvaRepositorio.Delete(id);
            _condicionIvaRepositorio.Save();
        }

        public IEnumerable<CondicionIvaDto> ObtenerPorFiltro(string buscar)
        {
            return _condicionIvaRepositorio.GetByFilter(x => x.Descripcion.Contains(buscar)
                                                             && x.Eliminado == false)
                .Select(x => new CondicionIvaDto()
                {
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Eliminado = x.Eliminado
                }).ToList();
        }



        public CondicionIvaDto ObtenerPorId(long id)
        {
            var iva = _condicionIvaRepositorio.GetById(id);

            if (iva == null) throw new Exception("No se encontro datos solicitados");

            return new CondicionIvaDto()
            {
                Codigo = iva.Codigo,
                Descripcion = iva.Descripcion,
                Eliminado = iva.Eliminado
            };
        }

        public IEnumerable<CondicionIvaDto> Obtener()
        {
            return _condicionIvaRepositorio.GetAll()
                .Select(x => new CondicionIvaDto()
                {
                    Id =x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public long  ObtenerCodigo()
        {
            return _condicionIvaRepositorio.GetAll().Any()
                ? _condicionIvaRepositorio.GetAll().Max(x => x.Codigo) + 1
                : 1;
        }

    }
}
