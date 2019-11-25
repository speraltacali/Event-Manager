using EM.Dominio.Base;
using EM.Infraestructura.Context;
using EM.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EM.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : EntityBase
    {
        protected DataContext Context;

        public Repositorio()
            : this(new DataContext())
        {
        }

        public Repositorio(DataContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            Context.Set<T>().Remove(entity);
        }

        //=====================================================================================================================================//
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> GetAll(string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //=====================================================================================================================================//
        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //=====================================================================================================================================//
        public T GetById(long entidadId)
        {
            return Context.Set<T>().Find(entidadId);
        }

        public T GetById(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T GetById(long id, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            query = includeProperties.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        //====================================================================================================================================//
        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}