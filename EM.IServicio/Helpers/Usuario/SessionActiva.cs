using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.IServicio.Helpers.Usuario
{
    public static class SessionActiva
    {
        public static long UsuarioId { get; set; }

        public static long PersonaId { get; set; }

        public static string ApyNom { get; set; }

        public static byte[] Foto { get; set; }

        //*********************Campos Temporales *************************//

        public static decimal Monto { get; set; }

        public static long EventoId { get; set; }

    }
}
