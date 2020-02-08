using EM.Dominio.Entity.MetaData;
using EM.IServicio.TipoEvento;
using EM.IServicio.TipoEvento.DTOs;
using EM.Servicio.TipoEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class TipoEventoController : Controller
    {
        ITipoEventoServicio _tipoEvento = new TipoEventoServicio();

        // GET: TipoEvento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NuevoEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoEvento(TipoEventoDto tipoEventoDto)
        {

            if (ModelState.IsValid)
            {

                _tipoEvento.Insert(tipoEventoDto);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}