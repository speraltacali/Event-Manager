using System.ComponentModel.DataAnnotations;

namespace EM.Dominio.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Timestamp]//para que entity sepa que va a trabajar con concurrencia
        public byte[] RowVersion { get; set; }
    }
}