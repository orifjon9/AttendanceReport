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

        private StudentRepository studentRepository;
        public StudentRepository StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                    this.studentRepository = new StudentRepository(this.context);

                return this.studentRepository;
            }
        }

        private EnrollmentRepository enrollmentRepository;
        public EnrollmentRepository EnrollmentRepository
        {
            get
            {
                if (this.enrollmentRepository == null)
                    this.enrollmentRepository = new EnrollmentRepository(this.context);

                return this.enrollmentRepository;
            }
        }

        private OfferedRepository offeredRepository;
        public OfferedRepository OfferedRepository
        {
            get
            {
                if (this.offeredRepository == null)
                    this.offeredRepository = new OfferedRepository(this.context);

                return this.offeredRepository;
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