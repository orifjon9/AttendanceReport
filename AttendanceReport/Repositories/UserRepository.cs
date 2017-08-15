using AttendanceReport.Helpers;
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

        public IEnumerable<UserViewModel> FindAll(string id)
        {
            if (id.Length > 0)
            {
                return context.userroles
                    .Where(w => w.UserName == id)
                    .ToList()
                    .Select(s=>ConvertTo(s));
            }

            return context.userroles
                .ToList()
                .Select(s => ConvertTo(s));
        }

        public UserViewModel GetById(object login)
        {
            return ConvertTo(context.userroles
                .Where(w => w.UserName == login.ToString())
                .FirstOrDefault());
        }

        public UserViewModel GetUser(String login, String password)
        {
            return ConvertTo(context.userroles
                .Where(w => w.UserName == login && w.Password == password)
                .FirstOrDefault());
            
        }

        private UserViewModel ConvertTo(userrole user)
        {
            if (user == null)
                return null;

            UserViewModel userViewModel = (UserViewModel)user;
            if (user.TypeId == (int)UserRole.Student)
            {
                userViewModel.Student = (StudentViewModel)context.students
                    .Where(w => w.StudentId == user.ObjectId)
                    .FirstOrDefault();
            }

            if (user.TypeId == (int)UserRole.Faculty)
            {
                int facultyId = Convert.ToInt32(user.ObjectId);
                userViewModel.Faculty = (FacultyViewModel)context.faculties
                    .Where(w => w.Id == facultyId)
                    .FirstOrDefault();
            }

            return userViewModel;
        }

        public bool Insert(UserViewModel userViewModel)
        {
            userrole userrole = new userrole()
            {
                UserName = userViewModel.UserName,
                Password = userViewModel.Password,
                TypeId = (int)userViewModel.Role,
                ObjectId = userViewModel.Role == UserRole.Student ? userViewModel.Student.StudentId : (userViewModel.Role == UserRole.Faculty ? userViewModel.Faculty.Id.ToString() : null)
            };

            context.userroles.Add(userrole);

            return true;
        }

        public bool Delete(UserViewModel userViewModel)
        {
            userrole userrole = context.userroles.Where(w => w.UserName == userViewModel.UserName).FirstOrDefault();
            if (userrole != null)
            {
                context.userroles.Remove(userrole);
                return true;
            }

            return false;
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