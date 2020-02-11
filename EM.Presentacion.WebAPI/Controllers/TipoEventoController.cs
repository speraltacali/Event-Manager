using EM.Dominio.Entity.MetaData;
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
        ITipoEventoServicio _tipoEvento = new TipoEventoServicio();

        // GET: TipoEvento
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(string cadena)
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

        public ActionResult NuevoEvento()
        {
            return View();
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
            var tipo =_tipoEvento.ObtenerId(id);

            return View(tipo);
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
    }
}