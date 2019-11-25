using EM.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EM.Repositorio.Base
{
    public interface IRepositorioConsulta<T> where T : EntityBase
    {
        T GetById(long entidadId);

        T GetById(long id, params Expression<Func<T, object>>[] includeProperties);

        T GetById(long id, string includeProperties);

        //=====================================================================================================================================//

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAll(string includeProperties);

        //=====================================================================================================================================//

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, string includeProperties);
    }
}