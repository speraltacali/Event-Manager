using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Pais;
using EM.Dominio.Repositorio.Provincia;
using EM.Infraestructura.Repositorio.Pais;
using EM.Infraestructura.Repositorio.Provincia;
using EM.IServicio.Provincia;
using EM.IServicio.Provincia.DTOs;

namespace EM.Servicio.Provincia
{
    public class ProvinciaServicio : IProvinciaServicio
    {

        private readonly IProvinciaRepositorio _provinciaRepositorio = new ProvinciaRepositorio();
        private readonly IPaisRepositorio _paisRepositorio = new PaisRepositorio();


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

        public IEnumerable<ProvinciaDto> ObtenerPorFiltro(string buscar)
        {
            return _provinciaRepositorio.GetByFilter(x => x.Descripcion.Contains(buscar)
                                                          || x.Pais.Descripcion.Contains(buscar))
                .Select(x => new ProvinciaDto()
                {
                    Descripcion = x.Descripcion,
                    PaisId = x.PaisId
                }).ToList();
        }

        public IEnumerable<ProvinciaDto> Obtener()
        {
            return _provinciaRepositorio.GetAll()
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

        //****************************************** Insert por Defecto **************************************

        public void InsertarPorDefecto()
        {
            var Pais = _paisRepositorio.GetAll().FirstOrDefault(x => x.Descripcion == "Argentina");
            var validar = _provinciaRepositorio.GetAll().Any();

            if (!validar)
            {
                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Tucuman",
                    PaisId = Pais.Id
                });

                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Santa Fe",
                    PaisId = Pais.Id
                });

                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Catamarca",
                    PaisId = Pais.Id
                });

                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Salta",
                    PaisId = Pais.Id
                });

                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Rio Negro",
                    PaisId = Pais.Id
                });

                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Corriente",
                    PaisId = Pais.Id
                });

                Insertar(new ProvinciaDto()
                {
                    Descripcion = "Neuquen",
                    PaisId = Pais.Id
                });
            }
        }

    }
}
