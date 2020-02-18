using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EM.IServicio.Comprobante.DTOs;
using EM.IServicio.CreadorEvento;
using EM.IServicio.CreadorEvento.DTO;
using EM.IServicio.Entrada;
using EM.IServicio.Entrada.DTOs;
using EM.IServicio.Evento;
using EM.IServicio.Evento.DTOs;
using EM.IServicio.Fecha;
using EM.IServicio.Fecha.DTOs;
using EM.IServicio.FechaEvento;
using EM.IServicio.FechaEvento.DTOs;
using EM.IServicio.Helpers.Foto;
using EM.IServicio.Helpers.Usuario;
using EM.IServicio.TipoEvento;
using EM.Servicio.CreadorEvento;
using EM.Servicio.Entrada;
using EM.Servicio.Evento;
using EM.Servicio.Fecha;
using EM.Servicio.FechaEvento;
using EM.Servicio.TipoEvento;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoServicio _eventoServicio = new EventoServicio();
        private readonly ITipoEventoServicio _tipoEventoServicio = new TipoEventoServicio();
        private readonly IFechaServicio _fechaServicio = new FechaServicio();
        private readonly IFechaEventoServicio _fechaEventoServicio = new FechaEventoServicio();
        private readonly IEntradaServicio _entradaServicio = new EntradaServicio();
        private readonly ICreadorEventoServicio _creadorEventoServicio = new CreadorEventoServicio();


        // GET: Evento
        public ActionResult Crear()
        {

            if (Session["Usuario"] != null)
            {
                _tipoEventoServicio.InsertarPorDefecto();

                ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();

                //*************************************************************************//

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult Crear(EventoViewDto eventoViewDto, HttpPostedFileBase img)
        {

            using (var reader = new BinaryReader(img.InputStream))
            {
                eventoViewDto.Imagen = reader.ReadBytes(img.ContentLength);
            }


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
                    Imagen = eventoViewDto.Imagen
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

                var CreadorEvento = new CreadorEventoDto()
                {
                    EventoId = EventoObj.Id,
                    UsuarioId = SessionActiva.UsuarioId,
                    Fecha = DateTime.Now
                };

                _creadorEventoServicio.Insertar(CreadorEvento);

                //*************************************************************//

                return RedirectToAction("ViewEvento" , new {id = EventoObj.Id});

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public ActionResult ViewEvento(long id)
        {
            if (Session["Usuario"] != null)
            {
                if (!_creadorEventoServicio.ValidarAlCreador(SessionActiva.UsuarioId,id))
                {
                    var evento = _eventoServicio.ObtenerPorId(id);

                    var entrada = _entradaServicio.ObtenerPorIdEvento(evento.Id);

                    var auxfecha = _fechaEventoServicio.ObtenerPorIdEvento(evento.Id);

                    var fechaPrincipal = _fechaServicio.ObtenerPorId(auxfecha.FechaId);

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
                        Longitud = evento.Longitud,
                        Latitud = evento.Latitud,
                        Imagen = evento.Imagen
                    };


                    return View(eventoView);
                }
                else
                {
                    return RedirectToAction("PerfilEvento", new{ id = id});
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpGet]
        public ActionResult PerfilEvento(long id)
        {
            if (Session["Usuario"] != null)
            {

                var evento = _eventoServicio.ObtenerPorId(id);

                var entrada = _entradaServicio.ObtenerPorIdEvento(evento.Id);

                var auxfecha = _fechaEventoServicio.ObtenerPorIdEvento(evento.Id);

                var fechaPrincipal = _fechaServicio.ObtenerPorId(auxfecha.FechaId);

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
                    Longitud = evento.Longitud,
                    Latitud = evento.Latitud,
                    Imagen = evento.Imagen
                };


                return View(eventoView);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult GetImage(int id)
        {
            // fetch image data from database

            var evento = _eventoServicio.ObtenerPorId(id);

            return File(evento.Imagen, "image/jpg");
        }

        public ActionResult PagarEntrada(long id)
        {
            if(Session["Usuario"] != null)
            {
                var evento = _eventoServicio.ObtenerPorId(id);

                var entrada = _entradaServicio.ObtenerPorIdEvento(evento.Id);

                var auxfecha = _fechaEventoServicio.ObtenerPorIdEvento(evento.Id);

                var fechaPrincipal = _fechaServicio.ObtenerPorId(auxfecha.FechaId);

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
                    Longitud = evento.Longitud,
                    Latitud = evento.Latitud,
                    Imagen = evento.Imagen
                };

                SessionActiva.Monto = eventoView.Precio;
                SessionActiva.EventoId = eventoView.Id;

                return View(eventoView);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult PagarEntrada(ComprobanteViewDto dto)
        {
            try
            {
                //dto.Numero = 
                dto.Fecha = DateTime.Now;
                dto.SubTotal = SessionActiva.Monto;
                dto.Total = SessionActiva.Monto;
                dto.UsuarioId = SessionActiva.UsuarioId;
                dto.EventoId = SessionActiva.EventoId;
            }
            catch (Exception e)
            {
                ViewBag.Error = e;
                throw;
            }


            return View();
        }





        [HttpGet]
        public ActionResult CreateEntrada(long valor)
        {
            return View();
        }

    }
}