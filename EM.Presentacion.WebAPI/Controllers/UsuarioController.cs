using System;
using System.Web.Mvc;
using EM.IServicio.Helpers.Usuario;
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
            if (Session["Usuario"] != null)
            {
                Session.Remove("Usuario");
                SessionActiva.UsuarioId = 0;
                SessionActiva.PersonaId = 0;
                SessionActiva.ApyNom = null;

                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(UsuarioDto Usuario)
            {
            if(_usuarioServicio.ValidarAcceso(Usuario.User , Usuario.Password))
            {
                Session["Usuario"] = SessionActiva.ApyNom;
                TempData["Session"] = Session["Usuario"];
                return RedirectToAction("Perfil", "Persona");
            }
            else
            {
                ViewBag.ErrorUser = "Usuario o contraseña incorrectos , reintentar";
                return View();
            }
        }


        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Perfil", "Persona");
            }
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewDto UserPersona)
        {

            if (Session["Usuario"] == null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (UserPersona.Password == UserPersona.PasswordRep)
                        {
                            var Persona = new PersonaDto()
                            {
                                Id = UserPersona.Id,
                                Apellido = UserPersona.Apellido,
                                Nombre = UserPersona.Nombre,
                                Domicilio = UserPersona.Domicilio,
                                Cuil = UserPersona.Cuil,
                                FechaNacimiento = UserPersona.FechaNacimiento,
                                Mail = UserPersona.Mail,
                                Telefono = UserPersona.Telefono
                            };

                            var Usuario = new UsuarioDto()
                            {
                                User = UserPersona.User,
                                Password = UserPersona.Password,
                            };

                            //Verificar por el momento el insert en DB

                            var persona = _personaServicio.Insertar(Persona);
                            Usuario.PersonaId = persona.Id;
                            Usuario.FechaCreacion = DateTime.Now;
                            _usuarioServicio.Insertar(Usuario);

                            return RedirectToAction("Login", "Usuario");
                        }
                        else
                        {
                            //expecion no funciona

                            ViewBag.Error = "Repita la contraseña de manera correcta";
                            return View();
                        }
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErrorUsuario = "Error inesperado en el sistema , reintentar";
                        return View();
                    }

                }
                else
                {
                    return View();
                }
            }
            else
            {
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