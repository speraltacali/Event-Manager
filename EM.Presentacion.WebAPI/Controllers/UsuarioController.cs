﻿using System;
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
        public ActionResult Create(PersonaDto Persona, UsuarioDto Usuario)
        {

            if (Session["Usuario"] == null)
            {
                if (ModelState.IsValid)
                {
                    if (Usuario.Password == Usuario.PasswordRep)
                    {
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
    }
}