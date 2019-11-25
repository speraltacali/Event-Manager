using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Entity.Entidades;
using EM.Dominio.Entity.MetaData;
using EM.Dominio.Repositorio.Comprobante;
using EM.Dominio.Repositorio.FormaPago;
using EM.Dominio.Repositorio.TipoComprobante;
using EM.IServicio.Comprobante;
using EM.IServicio.Comprobante.DTOs;

namespace EM.Servicio.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        //Verificar si utilizamos las Interfaces

        private readonly IFormaPagoRepositorio _formaPagoRepositorio;
        private readonly ITipoComprobanteRepositorio _tipoComprobanteRepositorio;
        private readonly IComprobanteRepositorio _comprobanteRepositorio;

        public ComprobanteServicio(IFormaPagoRepositorio formaPagoRepositorio , ITipoComprobanteRepositorio
              tipoComprobanteRepositorio , IComprobanteRepositorio comprobanteRepositorio)
        {
            _formaPagoRepositorio = formaPagoRepositorio;
            _tipoComprobanteRepositorio = tipoComprobanteRepositorio;
            _comprobanteRepositorio = comprobanteRepositorio;
        }

        public IEnumerable<ComprobanteDto> Obtener(string buscar)
        {
            return _comprobanteRepositorio.GetByFilter(x => x.Fecha.Contains(buscar)
                                                            || x.Numero.ToString().Contains(buscar)
                                                            || x.Total.ToString().Contains(buscar))
                .Select(x => new ComprobanteDto()
                {
                    Numero = x.Numero,
                    Fecha = x.Fecha,
                    SubTotal = x.SubTotal,
                    Total = x.Total,
                    Descuento = x.Descuento,
                    TipoComprobanteId = x.TipoComprobanteId,
                    FormaPagoId = x.FormaPagoId
                })
                .ToList();
        }

        public IEnumerable<ComprobanteDto> ObtenerTodo()
        {
            return _comprobanteRepositorio.GetAll()
                .Select(x => new ComprobanteDto()
                {
                    Numero = x.Numero,
                    Fecha = x.Fecha,
                    SubTotal = x.SubTotal,
                    Total = x.Total,
                    Descuento = x.Descuento,
                    TipoComprobanteId = x.TipoComprobanteId,
                    FormaPagoId = x.FormaPagoId
                })
                .ToList();
        }

        public ComprobanteDto ObtenerPoId(long id)
        {
            var comprobante = _comprobanteRepositorio.GetById(id);

            if (comprobante == null) throw new Exception("No se encontro registro solicitado");

            return new ComprobanteDto()
            {
                Numero = comprobante.Numero,
                Fecha = comprobante.Fecha,
                SubTotal = comprobante.SubTotal,
                Total = comprobante.Total,
                Descuento = comprobante.Descuento,
                TipoComprobanteId = comprobante.TipoComprobanteId,
                FormaPagoId = comprobante.FormaPagoId
            };
        }
    }
}
