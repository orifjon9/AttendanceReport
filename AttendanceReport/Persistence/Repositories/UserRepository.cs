using AttendanceReport.Core.Repositories;
using AttendanceReport.Helpers;
using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AttendanceReport.Persistence.Repositories
{
    public class UserRepository : Repository<userrole>, IUserRepository
    {
        private AttendanceDBEntities context;

        public UserRepository(AttendanceDBEntities context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<UserViewModel> FindAll()
        {
            return this.GetAll().ToList().Select(s => (UserViewModel)s);
        }

        public IEnumerable<UserViewModel> FindAll(string id)
        {
            if (id.Length > 0)
            {
                return Find(w => w.UserName == id).ToList()
                    .Select(s => ConvertTo(s));
            }

            return GetAll()
                .Select(s => ConvertTo(s));
        }

        public UserViewModel GetById(string login)
        {
            return ConvertTo(context.userroles
                .Where(w => w.UserName == login.ToString())
                .FirstOrDefault());
        }

        public UserViewModel Find(String login, String password)
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

        public bool Add(UserViewModel model)
        {
            userrole userrole = new userrole()
            {
                UserName = model.UserName,
                Password = model.Password,
                TypeId = (int)model.Role,
                ObjectId = model.Role == UserRole.Student ? model.Student.StudentId : (model.Role == UserRole.Faculty ? model.Faculty.Id.ToString() : null)
            };

            this.Add(userrole);

            return true;
        }

        public bool Delete(UserViewModel model)
        {
            userrole userrole = context.userroles
                .Where(w => w.UserName == model.UserName)
                .FirstOrDefault();

            if (userrole != null)
            {
                Remove(userrole);
                return true;
            }

            return false;
        }
    }
}