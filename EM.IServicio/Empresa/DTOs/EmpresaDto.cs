using EM.Servicio.Base.DtoBase;

namespace EM.IServicio.Empresa.DTOs
{
    public class EmpresaDto : DtoBase
    {
        public string Cuil { get; set; }

        public string NombreFantasia { get; set; }

        public string RazonSocial { get; set; }

        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public byte[] Imagen { get; set; }

        public bool Eliminado { get; set; }

        //==============================================================================//

        public  long CondicionIvaId { get; set; }
    }
}