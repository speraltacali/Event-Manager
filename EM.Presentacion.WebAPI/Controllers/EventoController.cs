using System;
using System.Linq;
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
        public ActionResult Crear(EventoViewDto eventoViewDto)
        {
            ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();

            if (ModelState.IsValid)
            {

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

                var traerEvento = _eventoServicio.ObtenerPorTitulo(evento.Titulo);

                var TraerEvento = new EventoViewDto
                {
                    Id = EventoObj.Id,
                    Titulo = traerEvento.Titulo,
                    Descripcion = traerEvento.Descripcion,
                    Mail = traerEvento.Mail,
                    Latitud = traerEvento.Latitud,
                    Longitud = traerEvento.Longitud,
                    TipoEventoId = traerEvento.TipoEventoId,
                    Calle = eventoViewDto.CalleNumero,
                    CalleNumero = eventoViewDto.CalleNumero,
                    FechaEvento = eventoViewDto.FechaEvento,
                    Telefono = eventoViewDto.Telefono,
                    Organizacion = eventoViewDto.Organizacion,
                    Precio = eventoViewDto.Precio,
                    Orante = eventoViewDto.Orante,
                    HoraFin = eventoViewDto.HoraFin,
                    HoraInicio = eventoViewDto.HoraInicio,
                    //Imagen
                };

                return ViewEvento(eventoViewDto);

            }
            else
            {
                return ViewEvento(eventoViewDto);
            }
        }

        public ActionResult ViewEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewEvento(EventoViewDto evento)
        {
            return View();
        }

    }
}