using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Entity.MetaData
{
    public interface IEventoLugar
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        long EventoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        long LugarId { get; set; }
    }
}