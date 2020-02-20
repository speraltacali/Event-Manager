using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Dominio.Entity.Entidades;
using EM.IServicio.Evento;
using EM.IServicio.Pais;
using EM.Repositorio;
using EM.Repositorio.Base;
using EM.Servicio.Evento;
using EM.Servicio.Pais;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private IRepositorio<Pais> _repositorio = new Repositorio<Pais>();

        private IEventoServicio _eventoServicio = new EventoServicio();

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

        public ActionResult GetImage(int id)
        {
            // fetch image data from database
            try
            {
                var evento = _eventoServicio.ObtenerPorId(id);

                return File(evento.Imagen, "image/jpg");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult BuscarEvento(string search)
        {
            if (search == null)
            {
                return View();
            }

            ViewBag.Busqueda = search;

            return View();
        }

    }
}
