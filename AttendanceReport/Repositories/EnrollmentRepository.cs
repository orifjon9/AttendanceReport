using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class EnrollmentRepository : IRepository<EnrollmentViewModel, offered>, IDisposable
    {
        private AttendanceDBEntities context;
        private bool disposed = false;

        public EnrollmentRepository(AttendanceDBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<EnrollmentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EnrollmentViewModel GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public List<EnrollmentViewModel> GetByStudentID(string studentID)
        {
            return context.enrollments
                .Where(w => w.StudentId == studentID)
                .ToList()
                .Select(s=>(EnrollmentViewModel)s)
                .ToList();
        }
        
        public bool Insert(EnrollmentViewModel t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EnrollmentViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrollmentViewModel t)
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