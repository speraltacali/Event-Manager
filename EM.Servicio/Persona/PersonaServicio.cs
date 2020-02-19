using EM.Dominio.Repositorio.Persona;
using EM.IServicio.Persona;
using EM.IServicio.Persona.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Comprobante;
using EM.Dominio.Repositorio.Usuario;
using EM.Infraestructura.Repositorio.Comprobante;
using EM.Infraestructura.Repositorio.Persona;
using EM.Infraestructura.Repositorio.Usuario;

namespace EM.Servicio.Persona
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio = new PersonaRepositorio();
        private readonly IComprobanteRepositorio _comprobanteRepositorio = new ComprobanteRepositorio();
        private readonly IUsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();


        public IEnumerable<PersonaDto> Obtener(string cadenabuscar)
        {
            return _personaRepositorio.GetByFilter(x => x.Apellido.Contains(cadenabuscar)
            || x.Nombre.Contains(cadenabuscar) || x.Cuil == cadenabuscar)
                .Select(x => new PersonaDto
                {
                    Id = x.Id,
                    RowVersion = x.RowVersion,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    Domicilio = x.Domicilio,
                    Cuil = x.Cuil,
                    FechaNacimiento = x.FechaNacimiento,
                    Mail = x.Mail,
                    Telefono = x.Telefono
                })
                .ToList();
        }

        public IEnumerable<PersonaDto> ObtenerPorEventoPago(long id)
        {
            List<PersonaDto> ListaParticipante = new List<PersonaDto>();

            var Validar = _comprobanteRepositorio.GetAll().Any();

            if(Validar)
            {
                var Comprobante = _comprobanteRepositorio.GetByFilter(x => x.EventoId == id);

                foreach (var pago in Comprobante)
                {
                    var Usuario = _usuarioRepositorio.GetById(pago.UsuarioId);

                    var Persona = _personaRepositorio.GetById(Usuario.PersonaId);


                    ListaParticipante.Add(new PersonaDto()
                    {
                        Id = Persona.Id,
                        Apellido = Persona.Apellido,
                        Nombre = Persona.Nombre,
                        Domicilio = Persona.Domicilio,
                        Cuil = Persona.Cuil,
                        FechaNacimiento = Persona.FechaNacimiento,
                        Mail = Persona.Mail,
                        Telefono = Persona.Telefono
                    });
                }
            }

            return ListaParticipante.ToList();
        }

        public IEnumerable<PersonaDto> ObtenerTodo()
        {
            return _personaRepositorio.GetAll()
                .Select(x => new PersonaDto
                {
                    Id = x.Id,
                    RowVersion = x.RowVersion,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    Domicilio = x.Domicilio,
                    Cuil = x.Cuil,
                    FechaNacimiento = x.FechaNacimiento,
                    Mail = x.Mail,
                    Telefono = x.Telefono
                })
                .ToList();

        }

        public PersonaDto ObtenerPorId(long id)
        {
            var persona = _personaRepositorio.GetById(id);

            return new PersonaDto
            {
                Id = persona.Id,
                RowVersion = persona.RowVersion,
                Apellido = persona.Apellido,
                Nombre = persona.Nombre,
                Cuil = persona.Cuil,
                Domicilio = persona.Domicilio,
                FechaNacimiento = persona.FechaNacimiento,
                Mail = persona.Mail,
                Telefono = persona.Telefono
            };
        }

        public PersonaDto Insertar(PersonaDto dto)
        {
            var persona = new Dominio.Entity.Entidades.Persona
            {
                Apellido = dto.Apellido,
                Nombre = dto.Nombre,
                Domicilio = dto.Domicilio,
                Cuil = dto.Cuil,
                FechaNacimiento = dto.FechaNacimiento,
                Telefono = dto.Telefono,
                Mail = dto.Mail
            };

            _personaRepositorio.Add(persona);

            _personaRepositorio.Save();

            return ObtenerPorId(persona.Id);
        }

        public void Modificar(PersonaDto dto)
        {
            var persona = _personaRepositorio.GetById(dto.Id);

            persona.Apellido = dto.Apellido;
            persona.Nombre = dto.Nombre;
            persona.Mail = dto.Mail;
            persona.Cuil = dto.Cuil;
            persona.Domicilio = dto.Domicilio;
            persona.FechaNacimiento = dto.FechaNacimiento;
            persona.Telefono = dto.Telefono;

            _personaRepositorio.Update(persona);

            _personaRepositorio.Save();


        }

        public void Eliminar(long id)
        {
            _personaRepositorio.Delete(id);

            _personaRepositorio.Save();
        }

        public bool ValidarMail(string mail)
        {
            var Persona = _personaRepositorio.GetByFilter(x => x.Mail == mail);

            if (Persona.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarCuil(string cuil)
        {
            var Persona = _personaRepositorio.GetByFilter(x => x.Cuil == cuil);

            if (Persona.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Guardar()
        {
            _personaRepositorio.Save();
        }

    }
}
