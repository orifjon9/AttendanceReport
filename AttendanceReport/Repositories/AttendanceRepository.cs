using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class AttendanceRepository : IRepository<AttendanceRecordViewModel, attendance_record>, IDisposable
    {
        private AttendanceDBEntities context;
        private bool disposed = false;

        public AttendanceRepository(AttendanceDBEntities context)
        {
            this.context = context;
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

        public AttendanceRecordViewModel GetById(object Id)
        {
            throw new NotImplementedException();
        }

        
        public IEnumerable<AttendanceRecordViewModel> GetAll()
        {
            return context.attendance_record.ToList()
                .Select(s => new AttendanceRecordViewModel(s))
                .ToList();
        }

        public bool Insert(AttendanceRecordViewModel t)
        {
            throw new NotImplementedException();
        }

        public bool Update(AttendanceRecordViewModel t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AttendanceRecordViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}