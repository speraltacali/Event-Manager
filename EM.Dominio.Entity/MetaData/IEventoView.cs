using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Dominio.Entity.MetaData
{
    public interface IEventoView
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Orante { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Organizacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Localizacion es obligatorio")]
        string Latitud { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string Longitud { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]

        //string Calle { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]

        //string CalleNumero { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Tipo Evento es obligatorio")]
        long TipoEventoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        byte[] Imagen { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string Telefono { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        decimal Precio { get; set; }

        long EntradaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        DateTime FechaEvento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        DateTime HoraInicio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        DateTime HoraFin { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        string DomicilioCompleto { get; set; }
    }
}
