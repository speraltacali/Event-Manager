using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Pais;
using EM.IServicio.Pais;
using EM.IServicio.Pais.DTOs;

namespace EM.Servicio.Pais
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio _paisRepositorio;

        public PaisServicio(IPaisRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        public void Insertar(PaisDto pais)
        {
            _paisRepositorio.Add(new Dominio.Entity.Entidades.Pais()
            {
                Descripcion = pais.Descripcion,
                FileName = pais.FileName,
                Path = pais.Path,
                RowVersion = pais.RowVersion
            });

            _paisRepositorio.Save();
        }

        public void Modificar(PaisDto pais)
        {
            _paisRepositorio.Update(new Dominio.Entity.Entidades.Pais()
            {
                Descripcion = pais.Descripcion,
                FileName = pais.FileName,
                Path = pais.Path,
                RowVersion = pais.RowVersion
            });

            _paisRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            _paisRepositorio.Delete(id);

            _paisRepositorio.Save();
        }

        public IEnumerable<PaisDto> Obtener(string cadenabuscar)
        {
            return _paisRepositorio.GetByFilter(x => x.Descripcion.Contains(cadenabuscar))
                .Select(x => new PaisDto
                {
                    Descripcion = x.Descripcion,
                    FileName = x.FileName,
                    Path = x.Path,
                    RowVersion = x.RowVersion
                })
                .ToList();
        }

        public PaisDto ObtenerPorId(long Id)
        {
            var x = _paisRepositorio.GetById(Id);

            return new PaisDto()
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                FileName = x.FileName,
                Path = x.Path,
                RowVersion = x.RowVersion,
            };
        }
    }
}
