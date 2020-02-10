using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.CondicionIva;
using EM.IServicio.CondicionIva.DTOs;
using EM.Servicio.CondicionIva;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class CondicionIvaController : Controller
    {
        private ICondicionIvaServicio _condicionIvaServicio = new CondicionIvaServicio();

        // GET: CondicionIva
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CondicionIvaDto condicionIva)
        {
            if (ModelState.IsValid)
            {
                _condicionIvaServicio.Insertar(condicionIva);
            }

            return View();
        }
    }
}