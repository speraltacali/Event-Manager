using EM.Dominio.Entity.Entidades;
using EM.Repositorio;
using EM.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EM.Infraestructura.Repositorio.Persona;
using EM.IServicio.Persona;
using EM.IServicio.Persona.DTOs;
using EM.Servicio.Persona;

namespace WebApplication1nn.Controllers
{
    public class PersonaController : ApiController
    {
        

        [HttpGet]
        public IEnumerable<Persona> Obtener()
        {
            return _repositorio.GetAll();
        }


        [HttpGet]
        public Persona ObtenerPersona(long id)
        {
             return _repositorio.GetById(id);
            
        }
        
        [HttpPost]
        public Persona Insertar(Persona dto)
        {
            _repositorio.Add(dto);
            _repositorio.Save();
            return dto;
        }

        [HttpDelete]
        public string Delete(long id)
        {
            _repositorio.Delete(id);
            _repositorio.Save();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public void Update(Persona dto)
        {
            _repositorio.Update(dto);
            _repositorio.Save();            
        }
    }
}
