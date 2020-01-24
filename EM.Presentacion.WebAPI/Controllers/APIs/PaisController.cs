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
    public class PaisController : ApiController
    {
        private readonly IRepositorio<Pais> _repositorio = new Repositorio<Pais>();

        public IEnumerable<Pais> ObtenerTodo()
        {
            return _repositorio.GetAll();
        }

        public IEnumerable<Pais> ObtenerPorFiltro(string cadena)
        {
            return _repositorio.GetByFilter(x => x.Descripcion.Contains(cadena)).ToList();
        }



    }
}
