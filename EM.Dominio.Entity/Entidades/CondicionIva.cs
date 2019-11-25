using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Base;
using EM.Dominio.Entity.MetaData;

namespace EM.Dominio.Entity.Entidades
{
    [Table("CondicionIva")]
    [MetadataType(typeof(ICondicionIva))]
    public class CondicionIva : EntityBase
    { 
        public long Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        //==============================================================================//

        public IEnumerable<Empresa> Empresas { get; set; }
    }
}
