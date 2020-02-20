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
using EM.Infraestructura.Repositorio.Comprobante;
using EM.IServicio.Comprobante;
using EM.IServicio.Comprobante.DTOs;

namespace EM.Servicio.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        //Verificar si utilizamos las Interfaces

        private readonly IComprobanteRepositorio _comprobanteRepositorio = new ComprobanteRepositorio();

        public IEnumerable<ComprobanteDto> Obtener(string buscar)
        {
            return _comprobanteRepositorio.GetByFilter(x => x.Numero.ToString().Contains(buscar)
                                                            || x.Total.ToString().Contains(buscar))
                .Select(x => new ComprobanteDto()
                {
                    Numero = x.Numero,
                    Fecha = x.Fecha,
                    SubTotal = x.SubTotal,
                    Total = x.Total,
                    Descuento = x.Descuento,
                    EventoId = x.EventoId,
                    UsuarioId = x.UsuarioId
                })
                .ToList();
        }

        public ComprobanteDto ObtenerPorEventoUser(long eventoId , long userId)
        {
            var comprobante = _comprobanteRepositorio.GetAll().FirstOrDefault(x => x.EventoId == eventoId
                                                                                   || x.UsuarioId == userId);


                return new ComprobanteDto()
                {
                    Numero = comprobante.Numero,
                    Fecha = comprobante.Fecha,
                    SubTotal = comprobante.SubTotal,
                    Total = comprobante.Total,
                    Descuento = comprobante.Descuento,
                    EventoId = comprobante.EventoId,
                    UsuarioId = comprobante.UsuarioId
                };
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
                    EventoId = x.EventoId,
                    UsuarioId = x.UsuarioId
                })
                .ToList();
        }

        public ComprobanteDto ObtenerPoId(long id)
        {
            var comprobante = _comprobanteRepositorio.GetById(id);

            if (comprobante == null) throw new Exception("No se encontro registro solicitado");

            return new ComprobanteDto()
            {
                Id = comprobante.Id,
                Numero = comprobante.Numero,
                Fecha = comprobante.Fecha,
                SubTotal = comprobante.SubTotal,
                Total = comprobante.Total,
                Descuento = comprobante.Descuento,
                EventoId = comprobante.EventoId,
                UsuarioId = comprobante.UsuarioId
            };
        }

        public List<ComprobanteDto> ObtenerPoIdUsuario(long id)
        {
            var comprobante = _comprobanteRepositorio.GetByFilter(x=>x.UsuarioId == id);

            if (comprobante == null) throw new Exception("No se encontro registro solicitado");

            List<ComprobanteDto> Lista = new List<ComprobanteDto>();

            foreach (var item in comprobante)
            {
                var aux = new ComprobanteDto()
                {
                    Id = item.Id,
                    Numero = item.Numero,
                    Fecha = item.Fecha,
                    SubTotal = item.SubTotal,
                    Total = item.Total,
                    Descuento = item.Descuento,
                    EventoId = item.EventoId,
                    UsuarioId = item.UsuarioId
                };

                Lista.Add(aux);

            }

            return Lista;

        }

        public ComprobanteDto Insertar(ComprobanteDto dto)
        {
            var Comprobante = new Dominio.Entity.Entidades.Comprobante()
            {
                Numero = dto.Numero,
                Fecha = dto.Fecha,
                SubTotal = dto.SubTotal,
                Total = dto.Total,
                Descuento = dto.Descuento,
                EventoId = dto.EventoId,
                UsuarioId = dto.UsuarioId
            };

            _comprobanteRepositorio.Add(Comprobante);
            Guardar();

            dto.Id = Comprobante.Id;
            return dto;

        }

        public decimal TotalComprobantePorEvento(long eventoId)
        {
            decimal aux = 0;

            var validacion = _comprobanteRepositorio.GetAll().Any();

            if(validacion)
            {
                var comprobante =_comprobanteRepositorio.GetByFilter(x => x.EventoId == eventoId);

                foreach (var precio in comprobante)
                {
                    aux += precio.Total;
                }
            }

            return aux;
        }

        public long ObtenerCodigo()
        {
            return _comprobanteRepositorio.GetAll().Any()
                ? _comprobanteRepositorio.GetAll().Max(x => x.Numero) + 1
                : 1;
        }

        public void Guardar()
        {
            _comprobanteRepositorio.Save();
        }

        //***************************** Validacion ******************************

        public bool ValidarCómprobanteEvento(long eventoId , long userId)
        {
            var validar = _comprobanteRepositorio.GetByFilter(x => x.EventoId == eventoId && x.UsuarioId == userId)
                .ToList();

            if(validar.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
