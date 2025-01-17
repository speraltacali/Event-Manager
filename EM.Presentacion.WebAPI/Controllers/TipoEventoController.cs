﻿using EM.Dominio.Entity.MetaData;
using EM.IServicio.TipoEvento;
using EM.IServicio.TipoEvento.DTOs;
using EM.Servicio.TipoEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly ITipoEventoServicio _tipoEvento = new TipoEventoServicio();

        // GET: TipoEvento
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(string cadena)
        {
            if(Session["Usuario"] != null)
            {
                ViewData["Busqueda"] = cadena;

                if (!String.IsNullOrEmpty(cadena))
                {
                    var ListaTipos = _tipoEvento.GetByFilter(cadena);
                    return View(ListaTipos);
                }
                else
                {
                    var list = _tipoEvento.Get();

                    return View(list);
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult NuevoEvento()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
    

        [HttpPost]
        public ActionResult NuevoEvento(TipoEventoDto tipoEventoDto)
        {

            if (ModelState.IsValid)
            {

                _tipoEvento.Insert(tipoEventoDto);

                return RedirectToAction("Index", "TipoEvento");
            }

            return View();
        }

        public ActionResult Update(long id)
        {

            if (Session["Usuario"] != null)
            {
                var tipo = _tipoEvento.ObtenerId(id);

                return View(tipo);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Update(TipoEventoDto tipoEventoDto)
        {
            if (ModelState.IsValid)
            {
                var tipo = _tipoEvento.ObtenerId(tipoEventoDto.Id);

                tipo.Descripcion = tipoEventoDto.Descripcion;

                _tipoEvento.Update(tipo);

                return RedirectToAction("Index", "TipoEvento");
            }

            return RedirectToAction("Index", "TipoEvento");
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