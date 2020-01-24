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
    public class DomicilioController : ApiController
    {
        private readonly IRepositorio<Domicilio> _repositorio = new Repositorio<Domicilio>();

        public IEnumerable<Domicilio> ObtenerTodo()
        {
            return _repositorio.GetAll();
        }

        public IEnumerable<Domicilio> ObtenerPorFiltro(string cadena)
        {
            return _repositorio.GetByFilter(x => x.Descripción.Contains(cadena)).ToList();
        }
    }
}
