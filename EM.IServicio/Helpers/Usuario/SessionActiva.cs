﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.IServicio.Helpers.Usuario
{
    public static class SessionActiva
    {
        public static long Id { get; set; }

        public static string ApyNom { get; set; }

        public static byte[] Foto { get; set; }
    }
}