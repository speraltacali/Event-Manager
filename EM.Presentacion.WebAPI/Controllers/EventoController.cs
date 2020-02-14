using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.Pais;
using EM.Infraestructura.Repositorio.Pais;
using EM.IServicio.Empresa;
using EM.IServicio.Entrada.DTOs;
using EM.IServicio.Evento;
using EM.IServicio.Evento.DTOs;
using EM.IServicio.Fecha.DTOs;
using EM.IServicio.Lugar.DTOs;
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
            _tipoEventoServicio.InsertarPorDefecto();

            ViewBag.ListaTipoEvento = _tipoEventoServicio.Get().ToList();
            
            //*************************************************************************//

            return View();
        }

        [HttpPost]
        public ActionResult Crear(EventoViewDto eventoViewDto)
        {
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

                };

                var lugar = new LugarDto
                {
                  Descripcion = eventoViewDto.DomicilioCompleto
                };

                var fecha = new FechaDto
                {
                    FechaInicio = eventoViewDto.FechaEvento//corregir
                };

                var entrada = new EntradaDto
                {
                    Monto = eventoViewDto.Precio//corregir
                };

                _eventoServicio.Insertar(evento);

                //devolver el evento creado

                var traerEvento = _eventoServicio.ObtenerPorTitulo(evento.Titulo);

                var TraerEvento = new EventoViewDto
                {
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

                return ViewEvento(TraerEvento);

            }

            return View();
        }

        public ActionResult ViewEvento()
        {
            return View();
        }

        public ActionResult ViewEvento(EventoViewDto evento)
        {
            return View();
        }

    }
}