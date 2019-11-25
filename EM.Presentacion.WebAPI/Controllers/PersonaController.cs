using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.Persona;
using EM.IServicio.Persona.DTOs;
using EM.Servicio.Persona;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class PersonaController : Controller
    {

        private IPersonaServicio _personaServicio = new PersonaServicio();

        // GET: Persona

        [HttpGet]
        public ActionResult Index()
        {

            var persona = _personaServicio.ObtenerTodo();

            return View(persona);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonaDto persona)
        {
            var Persona = _personaServicio.Agregar(persona);
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            var persona = _personaServicio.ObtenerPorId(id);
            return View(persona);
        }

        [HttpPost]
        public ActionResult Update(PersonaDto persona)
        {
            _personaServicio.Modificar(persona);
            return RedirectToAction("Index");
        }

    }
}