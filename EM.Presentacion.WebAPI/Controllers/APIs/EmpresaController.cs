using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EM.Dominio.Entity.Entidades;
using EM.Repositorio;
using EM.Repositorio.Base;

namespace EM.Presentacion.WebAPI.Controllers.APIs
{
    public class EmpresaController : ApiController
    {
        private readonly IRepositorio<Empresa> _repositorio = new Repositorio<Empresa>();


        [HttpGet]
        public IEnumerable<Empresa> ObtenerTodo()
        {
            return _repositorio.GetAll().ToList();
        }

        [HttpGet]
        public IEnumerable<Empresa> ObtenerPorFiltro(string cadena)
        {
            return _repositorio.GetByFilter(x => x.NombreFantasia.Contains(cadena)
                                                 || x.RazonSocial.Contains(cadena) && !x.Eliminado).ToList();
        }

    }
}
