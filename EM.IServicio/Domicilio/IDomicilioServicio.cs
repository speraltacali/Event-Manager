using EM.IServicio.Domicilio.DTOs;
using System.Collections.Generic;

namespace EM.IServicio.Domicilio
{
    public interface IDomicilioServicio
    {
        IEnumerable<DomicilioDto> ObtenerTodo();

        IEnumerable<DomicilioDto> Obtener(string cadenaBuscar);

        DomicilioDto ObtenerPotId(long id);

        void Insertar(DomicilioDto dto);

        void Modificar(DomicilioDto dto);
                                        
        void Eliminar(long id);

        void Guardar();
    }
}