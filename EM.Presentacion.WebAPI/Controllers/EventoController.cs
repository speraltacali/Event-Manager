using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Crear()
        {
            return View();
        }
    }
}