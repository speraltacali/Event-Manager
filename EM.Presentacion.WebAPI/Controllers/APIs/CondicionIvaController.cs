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
    public class CondicionIvaController : ApiController
    {
        private readonly IRepositorio<CondicionIva> _repositorio = new Repositorio<CondicionIva>();

        [HttpGet]
        public IEnumerable<CondicionIva> ObtenerTodo()
        {
            return _repositorio.GetAll().ToList();
        }

        [HttpGet]
        public IEnumerable<CondicionIva> ObtenerPorFiltro(string cadena)
        {
            return _repositorio.GetByFilter(x => x.Descripcion.Contains(cadena)
                                                 || x.Codigo.ToString().Contains(cadena)).ToList();
        }



    }
}
