using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AttendanceReport.Core.Repositories
{
    //public interface IRepository<T, U>
    //{
    //    T GetById(object Id);
    //    IEnumerable<T> GetAll();
    //    bool Insert(T t);
    //    bool Update(T t);
    //    bool Delete(T t);

    //    void Save();
    //}

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}