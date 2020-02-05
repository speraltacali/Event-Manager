using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Dominio.Entity.Entidades;
using EM.IServicio.Persona;
using EM.IServicio.Persona.DTOs;
using EM.IServicio.Usuario;
using EM.IServicio.Usuario.DTOs;
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

        [HttpPost]
        public ActionResult Create(PersonaDto Persona, UsuarioDto Usuario)
        {
            if (ModelState.IsValid)
            {
                if (Usuario.Password == Usuario.PasswordRep)
                {
                    //Verificar por el momento el insert en DB

                    var persona =_personaServicio.Insertar(Persona);
                    Usuario.PersonaId = persona.Id;
                    _usuarioServicio.Insertar(Usuario);
                }
                else
                {
                    //expecion no funciona

                    ViewBag.Error = "Repita la contraseña de manera correcta";
                    return View();
                }

            }

            return RedirectToAction("Index", "Home");
        }
    }
}