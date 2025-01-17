﻿using EM.IServicio.Persona.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Persona
{
    public interface IPersonaServicio
    {
        IEnumerable<PersonaDto> Obtener(string cadenabuscar);

        IEnumerable<PersonaDto> ObtenerPorEventoPago(long id);

        IEnumerable<PersonaDto> ObtenerTodo();

        PersonaDto ObtenerPorId(long id);

        PersonaDto Insertar(PersonaDto personaDto);

        void Modificar(PersonaDto personaDto);

        void Eliminar(long id);

        bool ValidarCuil(string cuil);

        bool ValidarMail(string mail);

        bool ValidarTelefono(string Telefono);

        void Guardar();

    }
}