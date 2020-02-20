using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.Helpers.Usuario;
using EM.IServicio.Persona;
using EM.IServicio.Persona.DTOs;
using EM.IServicio.Usuario;
using EM.Servicio.Persona;
using EM.Servicio.Usuario;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class PersonaController : Controller
    {

        private IPersonaServicio _personaServicio = new PersonaServicio();
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        // GET: Persona

        [HttpGet]
        public ActionResult Index()
        {

            var persona = _personaServicio.ObtenerTodo();

            return View(persona);
        }


        public ActionResult Perfil()
        {
            if(Session["Usuario"]!=null)
            {
                var Persona = _personaServicio.ObtenerPorId(SessionActiva.PersonaId);
                return View(Persona);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonaDto persona)
        {
            var Persona = _personaServicio.Insertar(persona);
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id )
        {

            if (Session["Usuario"] != null)
            {
                var persona = _personaServicio.ObtenerPorId(id);
                return View(persona);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Update(PersonaDto persona, HttpPostedFileBase img)
        {
            var obtenerUsuario = _usuarioServicio.ObtenerPorId(SessionActiva.UsuarioId);

            if (img != null)
            {
                using (var reader = new BinaryReader(img.InputStream))
                {
                    obtenerUsuario.Foto = reader.ReadBytes(img.ContentLength);
                    SessionActiva.Foto = obtenerUsuario.Foto;
                    _usuarioServicio.Modificar(obtenerUsuario);
                }
            }

            _personaServicio.Modificar(persona);
            return RedirectToAction("Perfil" ,"Persona");
        }

        public ActionResult GetImage(int id)
        {
            // fetch image data from database

            try
            {
                if (Session["Usuario"] != null)
                {
                    var usuario = _usuarioServicio.ObtenerPorId(id);

                    return File(usuario.Foto, "image/jpg");
                }
                else
                {
                    return RedirectToAction("Login", "Usuario");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorEvento = "Cargar una imagen para su evento";
                return RedirectToAction("Perfil", "Persona");
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