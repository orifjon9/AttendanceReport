using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private AttendanceDBEntities context = new AttendanceDBEntities();
        private bool disposed = false;
        
        private UserRepository userRepository;
        public UserRepository UserRepository {
            get {
                if (this.userRepository == null)
                    this.userRepository = new UserRepository(this.context);

                return this.userRepository;
            }
        }


        public void Save()
        {
            context.SaveChangesAsync();
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}