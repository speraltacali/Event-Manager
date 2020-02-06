using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Usuario;
using EM.Infraestructura.Repositorio.Usuario;
using EM.IServicio.Usuario;
using EM.IServicio.Usuario.DTOs;

namespace EM.Servicio.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();

        public IEnumerable<UsuarioDto> ObtenerTodo()
        {
            return _usuarioRepositorio.GetAll()
                .Select(x => new UsuarioDto()
                {
                    Id = x.Id,
                    User = x.User,
                    Password = x.Password,
                    Mail = x.Mail,
                    FechaCreacion = x.FechaCreacion,
                    PersonaId = x.PersonaId

                }).ToList();
        }

        public IEnumerable<UsuarioDto> Obtener(string cadenaBuscar)
        {
            return _usuarioRepositorio.GetByFilter(x => x.User.Contains(cadenaBuscar)
                                                        || x.Mail.Contains(cadenaBuscar) ||
                                                        x.FechaCreacion.ToString().Contains(cadenaBuscar))
                .Select(x => new UsuarioDto()
                {
                    Id = x.Id,
                    User = x.User,
                    Password = x.Password,
                    Mail = x.Mail,
                    FechaCreacion = x.FechaCreacion,
                    PersonaId = x.PersonaId
                }).ToList();
        }

        public UsuarioDto ObtenerPorId(long id)
        {
            var usuario = _usuarioRepositorio.GetById(id);

            if (usuario == null) throw new Exception("No se encontro el registro solicitado.");

            return new UsuarioDto()
            {
                Id = usuario.Id,
                User = usuario.User,
                Password = usuario.Password,
                Mail = usuario.Mail,
                FechaCreacion = usuario.FechaCreacion,
                PersonaId = usuario.PersonaId
            };
        }

        public void Insertar(UsuarioDto dto)
        {
            var usuario = new Dominio.Entity.Entidades.Usuario()
            {
                User = dto.User,
                Password = dto.Password,
                Mail = dto.Mail,
                FechaCreacion = dto.FechaCreacion,
                PersonaId = dto.PersonaId
            };

            _usuarioRepositorio.Add(usuario);
            Guardar();
        }

        public void Modificar(UsuarioDto dto)
        {
            var usuario = _usuarioRepositorio.GetById(dto.Id);

            if (usuario == null) throw new Exception("No se encontro el registro solicitado.");

            usuario.User = dto.User;
            usuario.Password = dto.Password;
            usuario.Mail = dto.Mail;
            usuario.FechaCreacion = dto.FechaCreacion;

            _usuarioRepositorio.Update(usuario);
            Guardar();

        }

        public void Eliminar(long id)
        {
            var usuario = _usuarioRepositorio.GetById(id);

            if (usuario == null) throw new Exception("No se encontro el registro solicitado.");

            _usuarioRepositorio.Delete(id);
            Guardar();

        }

        public void Guardar()
        {
            _usuarioRepositorio.Save();
        }


        //***********************************************************************************************************************
        //       ******************************************  LOGIN  ********************************************
        //***********************************************************************************************************************

        public UsuarioDto ValidarAcceso(string user , string pass)
        {
            var Usuario = _usuarioRepositorio.GetAll().FirstOrDefault(x => x.Password == pass && x.User == user);

            if (Usuario != null)
            {
                return new UsuarioDto()
                {
                    Id = Usuario.Id,
                    User = Usuario.User,
                    Password = Usuario.Password,
                    Mail = Usuario.Mail,
                    FechaCreacion = Usuario.FechaCreacion,
                    PersonaId = Usuario.PersonaId
                };
            }

            else
            {
                return null;
            }

        }


        //***********************************************************************************************************************
        //       ******************************************  VAIDACIONES  ********************************************
        //***********************************************************************************************************************

        public bool ValidarUser(string user)
        {
            var User = _usuarioRepositorio.GetByFilter(x => x.User == user);

            if(User != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarPass(string pass)
        {
            var Pass = _usuarioRepositorio.GetByFilter(x => x.Password == pass);

            if (Pass != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarMail(string mail)
        {
            var Mail = _usuarioRepositorio.GetByFilter(x => x.User == mail);

            if (Mail != null)
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
