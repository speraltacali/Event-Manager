using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Pais;
using EM.Dominio.Repositorio.Provincia;
using EM.IServicio.Provincia;
using EM.IServicio.Provincia.DTOs;

namespace EM.Servicio.Provincia
{
    public class ProvinciaServicio : IProvinciaServicio
    {

        private readonly IProvinciaRepositorio _provinciaRepositorio;
        private readonly IPaisRepositorio _paisRepositorio;

        public ProvinciaServicio(IProvinciaRepositorio provinciaRepositorio, IPaisRepositorio paisRepositorio)
        {
            _provinciaRepositorio = provinciaRepositorio;
            _paisRepositorio = paisRepositorio;
        }

        public void Insertar(ProvinciaDto provincia)
        {
            _provinciaRepositorio.Add(new Dominio.Entity.Entidades.Provincia()
            {
                Descripcion = provincia.Descripcion,
                PaisId = provincia.PaisId
                //Pais = _paisRepositorio.GetById(provincia.Id)
            });

            _provinciaRepositorio.Save();
        }

        public void Modificar(ProvinciaDto provincia)
        {
            var update = _provinciaRepositorio.GetById(provincia.Id);

            if (update == null) throw new Exception("No se encontro registro solicitado");

            _provinciaRepositorio.Update(new Dominio.Entity.Entidades.Provincia()
            {
                Descripcion = provincia.Descripcion,
                PaisId = provincia.PaisId
                //Pais = _paisRepositorio.GetById(provincia.Id)
            });

            _provinciaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var delete = _provinciaRepositorio.GetById(id);

            if (delete == null) throw new Exception("No se encontro registro solicitado");

            _provinciaRepositorio.Delete(id);
            _provinciaRepositorio.Save();
        }

        public IEnumerable<ProvinciaDto> Obtener(string buscar)
        {
            return _provinciaRepositorio.GetByFilter(x => x.Descripcion.Contains(buscar)
                                                          || x.Pais.Descripcion.Contains(buscar))
                .Select(x => new ProvinciaDto()
                {
                    Descripcion = x.Descripcion,
                    PaisId = x.PaisId
                }).ToList();
        }

        public ProvinciaDto ObtenerPorId(long id)
        {
            var provincia = _provinciaRepositorio.GetById(id);

            if (provincia == null) throw new Exception("No se encontro registro solicitado");

            return new ProvinciaDto()
            {
                Descripcion = provincia.Descripcion,
                PaisId = provincia.PaisId
            };
        }

    }
}
