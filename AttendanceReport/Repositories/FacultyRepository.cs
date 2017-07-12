using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class FacultyRepository : IRepository<FacultyViewModel, faculty>, IDisposable
    {
        private AttendanceDBEntities context;
        private bool disposed = false;

        public FacultyRepository(AttendanceDBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<FacultyViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FacultyViewModel GetById(object Id)
        {
            throw new NotImplementedException();
        }

        
        public bool Insert(FacultyViewModel t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(FacultyViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(FacultyViewModel t)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposed)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}