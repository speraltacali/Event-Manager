using EM.Dominio.Base;

namespace EM.Repositorio.Base
{
    public interface IRepositorioPersistencia<T> where T : EntityBase
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(long id);

        void Save();
    }
}