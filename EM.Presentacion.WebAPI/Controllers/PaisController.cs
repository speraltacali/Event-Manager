using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EM.Dominio.Entity.Entidades;
using EM.Repositorio;
using EM.Repositorio.Base;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class PaisController : ApiController
    {
        private IRepositorio<Pais> _repositorio = new Repositorio<Pais>();

        public IEnumerable<Pais> GetPais()
        {
            return _repositorio.GetAll();
        }

        public string PostPais(Pais pais)
        {
            _repositorio.Add(pais);
            _repositorio.Save();
            return "Se Guardo correctamente.";
        }

    }
}
