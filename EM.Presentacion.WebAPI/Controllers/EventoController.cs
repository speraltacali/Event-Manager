using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.Comprobante;
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
using EM.IServicio.Helpers.Usuario;
using EM.IServicio.TarjetaDebito;
using EM.IServicio.TarjetaDebito.DTO;
using EM.IServicio.TipoEvento;
using EM.Servicio.Comprobante;
using EM.Servicio.CreadorEvento;
using EM.Servicio.Entrada;
using EM.Servicio.Evento;
using EM.Servicio.Fecha;
using EM.Servicio.FechaEvento;
using EM.Servicio.TarjetaDebito;
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
        private readonly IComprobanteServicio _comprobanteServicio = new ComprobanteServicio();
        private readonly ITarjetaDebitoServicio _tarjetaDebitoServicio = new TarjetaDebitoServicio();

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

        public ActionResult Fecha(long id)
        {
            var fecha1 = _fechaEventoServicio.ObtenerPorIdEvento(id);

            var fecha2 = _fechaServicio.ObtenerPorId(fecha1.FechaId);

            return View(fecha2);
        }

        [HttpPost]
        public ActionResult Fecha(FechaDto fechaEventoDto)
        {

            _fechaServicio.Modificar(fechaEventoDto);

            return RedirectToAction("Perfil", "Persona");
        }

        public ActionResult SuspenderEvento(long id)
        {

            if (Session["Usuario"] != null)
            {
                var eventoView = EventoView(id);

                return View(eventoView);

            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult HabilitarEvento(long Id)
        {

            if (Session["Usuario"] != null)
            {

                _eventoServicio.EstadoActivo(Id);
                return RedirectToAction("PerfilEvento", new { id = Id });

            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult SuspenderEvento(EventoViewDto dto)
        {
            try
            {
                _eventoServicio.EstadoSuspendido(dto.Id);
                return RedirectToAction("PerfilEvento", new {id = dto.Id});

            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Crear(EventoViewDto eventoViewDto, HttpPostedFileBase img)
        {


            if (img != null)
            {
                using (var reader = new BinaryReader(img.InputStream))
                {
                    eventoViewDto.Imagen = reader.ReadBytes(img.ContentLength);
                }
            }
            else
            {
                ViewBag.ErrorEvento = "Ingrese una Imagen para su evento.";
                return View();
            }


            ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    if(!_eventoServicio.ValidarTitulo(eventoViewDto.Titulo))
                    {
                        if (!_eventoServicio.ValidarFecha(eventoViewDto.FechaEvento))
                        {
                            var evento = new EventoDto
                            {
                                Id = eventoViewDto.Id,
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

                            return RedirectToAction("ViewEvento", new { id = EventoObj.Id });

                        }
                        else
                        {
                            ViewBag.ErrorEvento = "Ingresa una fecha valida , anticipacion de 1 dia";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorEvento = "El Titulo del evento ya esta siendo utilizada.";
                        return View();
                    }
                }
                catch (Exception e)
                {
                    ViewBag.ErrorEvento = "Ocurrio un error inesperado en el sistema";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult ViewEvento(long id)
        {
            if (Session["Usuario"] != null)
            {
                if (!_creadorEventoServicio.ValidarAlCreador(SessionActiva.UsuarioId,id))
                {
                    var eventoView = EventoView(id);

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

                var eventoView = EventoView(id);


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

            try
            {
                if (Session["Usuario"] != null)
                {
                    var evento = _eventoServicio.ObtenerPorId(id);

                    return File(evento.Imagen, "image/jpg");
                }
                else
                {
                    return RedirectToAction("Login", "Usuario");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorEvento = "Cargar una imagen para su evento";
                return RedirectToAction("Crear", "Evento");
            }
        }

        public ActionResult PagarEntrada(long Id)
        {
            if(Session["Usuario"] != null)
            {
                if (!_comprobanteServicio.ValidarCómprobanteEvento(Id, SessionActiva.UsuarioId))
                {
                    var eventoView = EventoView(Id);

                    SessionActiva.Monto = eventoView.Precio;
                    SessionActiva.EventoId = eventoView.Id;

                    return View(eventoView);
                }
                else
                {
                    TempData["Pago"] = "Usted ya se inscribio al evento , verificar su Perfil - Entradas";
                    return RedirectToAction("ViewEvento", new {id = Id });
                }
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
                dto.Numero = _comprobanteServicio.ObtenerCodigo();
                dto.Fecha = DateTime.Now;
                dto.SubTotal = SessionActiva.Monto;
                dto.Total = dto.Total;
                dto.UsuarioId = SessionActiva.UsuarioId;
                dto.EventoId = dto.EventoId;

                var Comprobante = new ComprobanteDto()
                {
                    Numero = dto.Numero,
                    Fecha = dto.Fecha,
                    SubTotal = dto.SubTotal,
                    Total = dto.Total,
                    UsuarioId = dto.UsuarioId,
                    EventoId = dto.EventoId
                };

                dto.ComprobanteId = _comprobanteServicio.Insertar(Comprobante).Id;

                if (dto.Total > 0)
                {
                    var Tarjeta = new TarjetaDebitoDto()
                    {
                        NombreTitular = dto.NombreTitular,
                        Tarjeta = dto.Tarjeta,
                        Mes = dto.Mes,
                        Año = dto.Año,
                        CCV = dto.CCV,
                        ComprobanteId = dto.ComprobanteId
                    };

                    _tarjetaDebitoServicio.Insertar(Tarjeta);
                }
                //*****************************//


                return RedirectToAction("CreateEntrada", new { id = dto.EventoId });
            }
            catch (Exception e)
            {
                ViewBag.Error = e;

                return View();
            }

        }

        public ActionResult UpdateEvento(long id)
        {
            if (Session["Usuario"] != null)
            {
                ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();

                var evento = _eventoServicio.ObtenerPorId(id);

                return View(evento);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpPost]
        public ActionResult UpdateEvento(EventoDto evento, HttpPostedFileBase img)
        {
            if (img != null)
            {
                using (var reader = new BinaryReader(img.InputStream))
                {
                    evento.Imagen = reader.ReadBytes(img.ContentLength);
                }
            }

            var eventoimg = _eventoServicio.ObtenerPorId(evento.Id);

            if (evento.Imagen == null)
            {
                evento.Imagen = eventoimg.Imagen;
            }

            _eventoServicio.Modificar(evento);

            return RedirectToAction("Perfil", "Persona");
        }

        [HttpGet]
        public ActionResult CreateEntrada(long id)
        {
            if (Session["Usuario"] != null)
            {
                var eventoView = EventoView(id);

                return View(eventoView);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
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

        [HttpGet]
        public ActionResult VerEntrada(long Id)
        {

            if (Session["Usuario"] != null)
            {
                var comprobante = _comprobanteServicio.ObtenerPoId(Id);

                var eventoView = EventoView(comprobante.Id);

                return View(eventoView);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        public EventoViewDto EventoView(long id)
        {
            var entrada = _entradaServicio.ObtenerPorIdEvento(id);

            var auxfecha = _fechaEventoServicio.ObtenerPorIdEvento(id);

            var fechaPrincipal = _fechaServicio.ObtenerPorId(auxfecha.FechaId);

            if (fechaPrincipal.FechaEvento <= DateTime.Now)
            {
                CambiarEstadoVencido(id);
            }

            var evento = _eventoServicio.ObtenerPorId(id);

            var eventoView = new EventoViewDto
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Descripcion = evento.Descripcion,
                Mail = evento.Mail,
                TipoEventoId = evento.TipoEventoId,
                Orante = evento.Orante,
                Organizacion = evento.Organizacion,
                Telefono = evento.Telefono,
                Precio = entrada.Monto,
                Latitud = evento.Latitud,
                Longitud = evento.Longitud,
                Estado = evento.Estado,
                EntradaId = entrada.Id,
                Calle = evento.Domicilio,
                CalleNumero = evento.Domicilio,
                FechaEvento = fechaPrincipal.FechaEvento.Date,
                HoraFin = fechaPrincipal.HoraCierre,
                HoraInicio = fechaPrincipal.HoraInicio,
                Imagen = evento.Imagen
            };

            return eventoView;
        }

        public void CambiarEstadoVencido(long id)
        {
            _eventoServicio.EstadoVencido(id);
        }
    }
}