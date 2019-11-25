using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Entrada;
using EM.IServicio.Entrada;
using EM.IServicio.Entrada.DTOs;

namespace EM.Servicio.Entrada
{
    public class EntradaServicio : IEntradaServicio
    {
        private readonly IEntradaRepositorio _entradaRepositorio;

        public EntradaServicio(IEntradaRepositorio entradaRepositorio)
        {
            _entradaRepositorio = entradaRepositorio;
        }

        public IEnumerable<EntradaDto> ObtenerTodo()
        {
            return _entradaRepositorio.GetAll()
                .Select(x => new EntradaDto()
                {
                    Id = x.Id,
                    Monto = x.Monto,
                    FechaDesde = x.FechaDesde,
                    FechaHasta = x.FechaHasta,
                    Cantidad = x.Cantidad,
                    EventoId = x.EventoId,
                }).ToList();
        }

        public IEnumerable<EntradaDto> Obtener(string cadenaBuscar)
        {
            return _entradaRepositorio.GetByFilter(x=> x.Eventos.Descripcion.Contains(cadenaBuscar)
            || x.FechaDesde.ToString().Contains(cadenaBuscar)||x.FechaHasta.ToString().Contains(cadenaBuscar))
                .Select(x => new EntradaDto()
                {
                    Id = x.Id,
                    Monto = x.Monto,
                    FechaDesde = x.FechaDesde,
                    FechaHasta = x.FechaHasta,
                    Cantidad = x.Cantidad,
                    EventoId = x.EventoId,
                }).ToList();
        }

        public EntradaDto ObtenerPotId(long id)
        {
            var entrada = _entradaRepositorio.GetById(id);

            if(entrada == null)throw new Exception("No se encontro el registro solicitado.");

            return new EntradaDto()
            {
                Id = entrada.Id,
                Monto = entrada.Monto,
                FechaDesde = entrada.FechaDesde,
                FechaHasta = entrada.FechaHasta,
                Cantidad = entrada.Cantidad,
                EventoId = entrada.EventoId,
            };
        }

        public void Insertar(EntradaDto dto)
        {
            var entrada = new Dominio.Entity.Entidades.Entrada()
            {
                Monto = dto.Monto,
                FechaDesde = dto.FechaDesde,
                FechaHasta = dto.FechaHasta,
                Cantidad = dto.Cantidad,
                EventoId = dto.EventoId,
            };

            _entradaRepositorio.Add(entrada);
            Guardar();
        }

        public void Modificar(EntradaDto dto)
        {
            var entrada = _entradaRepositorio.GetById(dto.Id);

            if (entrada == null) throw new Exception("No se encontro el registro solicitado.");

            entrada.Monto = dto.Monto;
            entrada.FechaDesde = dto.FechaDesde;
            entrada.FechaHasta = dto.FechaHasta;
            entrada.Cantidad = dto.Cantidad;
            entrada.EventoId = dto.EventoId;

            _entradaRepositorio.Update(entrada);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var entrada = _entradaRepositorio.GetById(id);

            if (entrada == null) throw new Exception("No se encontro el registro solicitado.");

            _entradaRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _entradaRepositorio.Save();
        }
    }
}
