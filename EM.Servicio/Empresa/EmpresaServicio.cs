using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.CondicionIva;
using EM.Dominio.Repositorio.Empresa;
using EM.IServicio.Empresa;
using EM.IServicio.Empresa.DTOs;

namespace EM.Servicio.Empresa
{
    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly ICondicionIvaRepositorio _condicionIvaRepositorio;

        public EmpresaServicio(IEmpresaRepositorio empresaRepositorio, ICondicionIvaRepositorio condicionIvaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
            _condicionIvaRepositorio = condicionIvaRepositorio;
        }

        public void Insertar(EmpresaDto empresa)
        {
            _empresaRepositorio.Add(new Dominio.Entity.Entidades.Empresa()
            {
                NombreFantasia = empresa.NombreFantasia,
                RazonSocial = empresa.RazonSocial,
                Cuil = empresa.Cuil,
                Telefono = empresa.Telefono,
                Direccion = empresa.Direccion,
                Email = empresa.Email,
                Imagen = empresa.Imagen,
                Eliminado = empresa.Eliminado,
                CondicionIva = _condicionIvaRepositorio.GetById(empresa.CondicionIvaId)
            });

            _empresaRepositorio.Save();
        }

        public void Modificar(EmpresaDto empresa)
        {
            var update = _empresaRepositorio.GetById(empresa.Id);

            if (update == null) throw new Exception("No se encontro el registro solicitado");

            update.NombreFantasia = empresa.NombreFantasia;
            update.RazonSocial = empresa.RazonSocial;
            update.Cuil = empresa.Cuil;
            update.Telefono = empresa.Telefono;
            update.Direccion = empresa.Direccion;
            update.Email = empresa.Email;
            update.Imagen = empresa.Imagen;
            update.Eliminado = empresa.Eliminado;
            update.CondicionIva = _condicionIvaRepositorio.GetById(empresa.CondicionIvaId);

            _empresaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var delete = _empresaRepositorio.GetById(id);

            if (delete == null) throw new Exception("No se encontro el registro solicitado");

            _empresaRepositorio.Delete(id);
            _empresaRepositorio.Save();
        }


        public IEnumerable<EmpresaDto> Obtener(string buscar)
        {
            return _empresaRepositorio.GetByFilter(x => x.NombreFantasia.Contains(buscar)
                                                        || x.RazonSocial.Contains(buscar)
                                                        || x.Cuil.Contains(buscar)
                                                        && x.Eliminado == false)
                .Select(x => new EmpresaDto()
                {
                    NombreFantasia = x.NombreFantasia,
                    RazonSocial = x.RazonSocial,
                    Cuil = x.Cuil,
                    Telefono = x.Telefono,
                    Direccion = x.Direccion,
                    Email = x.Email,
                    Imagen = x.Imagen,
                    Eliminado = x.Eliminado,
                    CondicionIvaId = x.CondicionIva.Id
                }).ToList();
        }

        public EmpresaDto ObtenerPorId(long id)
        {
            var empresa = _empresaRepositorio.GetById(id);

            if (empresa == null) throw new Exception("No se encontro el registro solicitado");

            return new EmpresaDto()
            {
                NombreFantasia = empresa.NombreFantasia,
                RazonSocial = empresa.RazonSocial,
                Cuil = empresa.Cuil,
                Telefono = empresa.Telefono,
                Direccion = empresa.Direccion,
                Email = empresa.Email,
                Imagen = empresa.Imagen,
                Eliminado = empresa.Eliminado,
                CondicionIvaId = empresa.CondicionIva.Id
            };

        }
    }
}
