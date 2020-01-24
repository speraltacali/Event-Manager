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
    public class LugarController : ApiController
    {
        private readonly IRepositorio<Lugar> _repositorio = new Repositorio<Lugar>();

        public IEnumerable<Lugar> ObtenerTodo()
        {
            return _repositorio.GetAll();
        }

        public IEnumerable<Lugar> ObtenerPorFiltro(string cadena)
        {
            return _repositorio.GetByFilter(x => x.Descripcion.Contains(cadena));
        }
    }
}
