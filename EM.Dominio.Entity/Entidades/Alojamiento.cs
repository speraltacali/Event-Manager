﻿using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Dominio.Entity.Entidades
{
    [Table("Alojamientos")]
    [MetadataType(typeof(IAlojamiento))]
    public class Alojamiento : EntityBase
    {
        public long LugarId { get; set; }

        public string Descripcion { get; set; }

        public virtual Lugar Lugares { get; set; }
    }
}