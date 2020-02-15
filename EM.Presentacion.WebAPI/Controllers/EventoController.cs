using System;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EM.IServicio.Entrada;
using EM.IServicio.Entrada.DTOs;
using EM.IServicio.Evento;
using EM.IServicio.Evento.DTOs;
using EM.IServicio.Fecha;
using EM.IServicio.Fecha.DTOs;
using EM.IServicio.FechaEvento;
using EM.IServicio.FechaEvento.DTOs;
using EM.IServicio.TipoEvento;
using EM.Servicio.Entrada;
using EM.Servicio.Evento;
using EM.Servicio.Fecha;
using EM.Servicio.FechaEvento;
using EM.Servicio.TipoEvento;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EventoController : Controller
    {
        private IEventoServicio _eventoServicio = new EventoServicio();
        private ITipoEventoServicio _tipoEventoServicio = new TipoEventoServicio();
        private IFechaServicio _fechaServicio = new FechaServicio();
        private IFechaEventoServicio _fechaEventoServicio = new FechaEventoServicio();
        private IEntradaServicio _entradaServicio = new EntradaServicio();

        // GET: Evento
        public ActionResult Crear()
        {
            _tipoEventoServicio.InsertarPorDefecto();

            ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();
            
            //*************************************************************************//

            return View();
        }

        [HttpPost]
        public ActionResult Crear(EventoViewDto eventoViewDto , HttpPostedFileBase Imagen)
        {
            ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();

            if (ModelState.IsValid)
            {

                HttpPostedFileBase FileBase = Request.Files[0];

                WebImage image = new WebImage();

                var evento = new EventoDto
                {
                    Titulo = eventoViewDto.Titulo,
                    Descripcion = eventoViewDto.Descripcion,
                    Mail = eventoViewDto.Mail,
                    Latitud = eventoViewDto.Latitud,
                    Longitud = eventoViewDto.Longitud,
                    TipoEventoId = eventoViewDto.TipoEventoId,
                    Orante = eventoViewDto.Orante,
                    Organizacion = eventoViewDto.Organizacion,
                    Domicilio = eventoViewDto.DomicilioCompleto,
                    Telefono = eventoViewDto.Telefono,
                };

                var EventoObj = _eventoServicio.Insertar(evento);

                //*************************************************************//

                var fecha = new FechaDto
                {
                    FechaEvento = eventoViewDto.FechaEvento,
                    HoraInicio = eventoViewDto.HoraInicio,
                    HoraCierre = eventoViewDto.HoraFin
                };

                var FechaObj = _fechaServicio.Insertar(fecha);

                //*************************************************************//

                var fechaEvento = new FechaEventoDto
                {
                    EventosId = EventoObj.Id,
                    FechaId = FechaObj.Id
                };

                _fechaEventoServicio.Insertar(fechaEvento);

                //*************************************************************//

                var entrada = new EntradaDto
                {
                    Monto = eventoViewDto.Precio,
                    FechaDesde = DateTime.Now,
                    FechaHasta = DateTime.Now,
                    EventoId = EventoObj.Id,
                    Cantidad = 1
                };

                _entradaServicio.Insertar(entrada);

                //*************************************************************//

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return ViewEvento();
            }
        }

        public ActionResult ViewEvento()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewEvento(long id)
        {

            var evento = _eventoServicio.ObtenerPorId(id);

            var entrada = _entradaServicio.ObtenerPorIdEvento(evento.Id);

            var auxfecha = _fechaEventoServicio.ObtenerPorIdEvento(evento.Id);

            var fechaPrincipal = _fechaServicio.ObtenerPorId(auxfecha.FechaId);

            decimal lat2;
            decimal lng2;

            var lat = decimal.TryParse(evento.Latitud, out lat2);
            var lng = decimal.TryParse(evento.Longitud, out lng2);

            var eventoView = new EventoViewDto
            {
                Titulo = evento.Titulo,
                Descripcion = evento.Descripcion,
                Mail = evento.Mail,
                TipoEventoId = evento.TipoEventoId,
                Orante = evento.Orante,
                Organizacion = evento.Organizacion,
                Telefono = evento.Telefono,
                Precio = entrada.Monto,
                EntradaId = entrada.Id,
                Calle = evento.Domicilio,
                CalleNumero = evento.Domicilio,
                FechaEvento = fechaPrincipal.FechaEvento.Date,
                HoraFin = fechaPrincipal.HoraCierre,
                HoraInicio = fechaPrincipal.HoraInicio,
                Id = evento.Id,
                Lat = lat2,
                Lng = lng2,

            };

            return View(eventoView);
        }

    }
}