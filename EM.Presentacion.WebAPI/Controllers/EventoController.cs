﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.Pais;
using EM.Infraestructura.Repositorio.Pais;
using EM.IServicio.Empresa;
using EM.IServicio.Evento;
using EM.IServicio.Evento.DTOs;
using EM.IServicio.Pais;
using EM.IServicio.Provincia;
using EM.IServicio.TipoEvento;
using EM.Servicio.Empresa;
using EM.Servicio.Evento;
using EM.Servicio.Pais;
using EM.Servicio.Provincia;
using EM.Servicio.TipoEvento;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EventoController : Controller
    {
        private IEventoServicio _eventoServicio = new EventoServicio();
        private IEmpresaServicio _empresaServicio = new EmpresaServicio();
        private ITipoEventoServicio _tipoEventoServicio = new TipoEventoServicio();
        private IPaisServicio _paisServicio = new PaisServicio();
        private IProvinciaServicio _provinciaServicio = new ProvinciaServicio();


        // GET: Evento
        public ActionResult Crear()
        {

            ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();
            
            ViewBag.ListaEmpresa = _empresaServicio.Obtener();

            //*************************************************************************//

            _paisServicio.InsertarPorDefecto();

            ViewBag.ListaPais = _paisServicio.Obtener();

            _provinciaServicio.InsertarPorDefecto();

            ViewBag.ListaProvincia = _provinciaServicio.Obtener();

            return View();
        }

        [HttpPost]
        public ActionResult Crear(EventoDto eventoDto)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}