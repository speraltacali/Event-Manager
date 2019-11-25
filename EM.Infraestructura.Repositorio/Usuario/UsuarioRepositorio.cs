using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Usuario;
using EM.Repositorio;

namespace EM.Infraestructura.Repositorio.Usuario
{
    public class UsuarioRepositorio : Repositorio<Dominio.Entity.Entidades.Usuario> , IUsuarioRepositorio
    {
    }
}
