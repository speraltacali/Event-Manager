using EM.Dominio.Base;

namespace EM.Repositorio.Base
{
    public interface IRepositorio<T> : IRepositorioConsulta<T>, IRepositorioPersistencia<T> where T : EntityBase
    {
    }
}