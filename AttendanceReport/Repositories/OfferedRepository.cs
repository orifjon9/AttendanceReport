using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class OfferedRepository : IRepository<OfferedViewModel, offered>, IDisposable
    {
        private AttendanceDBEntities context;
        private bool disposed = false;

        public OfferedRepository(AttendanceDBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<OfferedViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public OfferedViewModel GetById(object Id)
        {
            int offeredId = Convert.ToInt32(Id);
            return (OfferedViewModel)context.offereds
                .Where(w => w.Id == offeredId)
                .FirstOrDefault();
        }

        public bool Insert(OfferedViewModel t)
        {
            throw new NotImplementedException();
        }

        public List<OfferedViewModel> GetByFacultyID(int facultyID)
        {
           return context.offereds.Where(w => w.FacultyId == facultyID)
                 .GroupBy(g => new { g.CourseNumber, g.StartDate })
                 .Select(s =>s.FirstOrDefault())
                 .OrderByDescending(o=>o.StartDate)
                 .ToArray()
                 .Select(s=>new OfferedViewModel(s))
                 .ToList();

        }

        public List<OfferedViewModel> GetByStudentID(string studentID)
        {
            return context.enrollments
                    .Where(w => w.StudentId == studentID).ToList()
                    .Select(s => new OfferedViewModel(s.offered)).ToList();
        }

        public bool Delete(OfferedViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(OfferedViewModel t)
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