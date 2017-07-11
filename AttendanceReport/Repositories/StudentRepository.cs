using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class StudentRepository : IRepository<StudentViewModel, student>, IDisposable
    {
        private AttendanceDBEntities context;
        private bool disposed = false;

        public StudentRepository(AttendanceDBEntities context)
        {
            this.context = context;
        }
        

        
        public IEnumerable<StudentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentViewModel GetById(object Id)
        {
            return (StudentViewModel)context.students.Where(w => w.StudentId == Id.ToString()).FirstOrDefault();
        }

        public bool Insert(StudentViewModel studentViewModel)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(StudentViewModel studentViewModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StudentViewModel studentViewModel)
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