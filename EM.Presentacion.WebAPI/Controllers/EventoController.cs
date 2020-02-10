using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.Evento.DTOs;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(EventoDto eventoDto)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}