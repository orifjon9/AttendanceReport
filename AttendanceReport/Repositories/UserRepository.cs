using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class UserRepository : IRepository<UserViewModel, userrole>, IDisposable
    {
        private AttendanceDBEntities context;
        private bool disposed = false;

        public UserRepository(AttendanceDBEntities context)
        {
            this.context = context;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return context.userroles.Select(s => (UserViewModel)s);
        }

        public UserViewModel GetById(object login)
        {
            return (UserViewModel)context.userroles
                .Where(w => w.UserName == login.ToString())
                .FirstOrDefault();
        }
        public async Task<UserViewModel> GetUserAsync(String login)
        {
            return (UserViewModel)context.userroles
                .Where(w => w.UserName == login)
                .FirstOrDefault();
        }

        public async Task<UserViewModel> GetUserAsync(String login, String password)
        {
            return (UserViewModel)context.userroles
                .Where(w => w.UserName == login && w.Password == password)
                .FirstOrDefault();
        }

        public bool Insert(UserViewModel t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserViewModel t)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposed) {
            if (!this.disposed) {
                if (disposed) {
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