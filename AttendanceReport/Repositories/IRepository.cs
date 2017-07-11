using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public interface IRepository<T, U>
    {
        T GetById(object Id);
        IEnumerable<T> GetAll();
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);

        void Save();
    }
}