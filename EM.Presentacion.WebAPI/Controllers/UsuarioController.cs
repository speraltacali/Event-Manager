using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.Persona;
using EM.IServicio.Usuario;
using EM.Servicio.Persona;
using EM.Servicio.Usuario;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioServicio _usuarioServicio = new UsuarioServicio();
        private IPersonaServicio _personaServicio = new PersonaServicio();

        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Usuario()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}