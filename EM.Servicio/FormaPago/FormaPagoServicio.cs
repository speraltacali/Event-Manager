using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.FormaPago;
using EM.IServicio.FormaPago;
using EM.IServicio.FormaPago.DTOs;

namespace EM.Servicio.FormaPago
{
    public class FormaPagoServicio : IFormaPagoServicio
    {
        private readonly IFormaPagoRepositorio _formaPagoRepositorio;

        public FormaPagoServicio(IFormaPagoRepositorio formaPagoRepositorio)
        {
            _formaPagoRepositorio = formaPagoRepositorio;
        }

        public IEnumerable<FormaPagoDto> ObtenerTodo()
        {
            return _formaPagoRepositorio.GetAll()
                .Select(x => new FormaPagoDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public IEnumerable<FormaPagoDto> Obtener(string cadenaBuscar)
        {
            return _formaPagoRepositorio.GetByFilter(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new FormaPagoDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public FormaPagoDto ObtenerPorId(long id)
        {
            var obtenerFormaPago = _formaPagoRepositorio.GetById(id);

            if(obtenerFormaPago == null) throw new Exception("No se a encontrado el registro solicitado");

            return new FormaPagoDto()
            {
                Id = obtenerFormaPago.Id,
                Descripcion = obtenerFormaPago.Descripcion
            };

        }

        public void Insertar(FormaPagoDto dto)
        {
            var formpaPago = new Dominio.Entity.Entidades.FormaPago()
            {
                Descripcion = dto.Descripcion
            }; 


            _formaPagoRepositorio.Add(formpaPago);
            Guardar();
        }

        public void Modificar(FormaPagoDto dto)
        {
            var formaPago = _formaPagoRepositorio.GetById(dto.Id);

            if(formaPago == null) throw new Exception("No se a encontrado el registro solicitado");

            formaPago.Descripcion = dto.Descripcion;

            _formaPagoRepositorio.Update(formaPago);
            Guardar();
        }

        public void Eliminar(long id)
        {
            var formaPago = _formaPagoRepositorio.GetById(id);

            if (formaPago == null) throw new Exception("No se a encontrado el registro solicitado");

            _formaPagoRepositorio.Delete(id);
            Guardar();
        }

        public void Guardar()
        {
            _formaPagoRepositorio.Save();
        }

    }
}
