using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class TipoEventoController : Controller
    {
        // GET: TipoEvento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NuevoEvento()
        {
            return View();
        }


    }
}