using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Dominio.Entity.Entidades;
using EM.IServicio.Pais;
using EM.Repositorio;
using EM.Repositorio.Base;
using EM.Servicio.Pais;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private IRepositorio<Pais> _repositorio = new Repositorio<Pais>();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            _repositorio.Add(new Pais()
            {
                Descripcion = "Argentina"
            });

            return View();
        }

        public ActionResult Eventos()
        {
            ViewBag.Title = "Eventos";

            return View();
        }

    }
}
