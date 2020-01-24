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
    public class TransporteController : ApiController
    {
        private readonly IRepositorio<Transporte> _repositorio = new Repositorio<Transporte>();

        public IEnumerable<Transporte> ObtenerTodo()
        {
            return _repositorio.GetAll();
        }

        public IEnumerable<Transporte> ObtenerPorFiltro(string cadena)
        {
            return _repositorio.GetByFilter(x => x.Descripcion.Contains(cadena)).ToList();
        }
    }
}
