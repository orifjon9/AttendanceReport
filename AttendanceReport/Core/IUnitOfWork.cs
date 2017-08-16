using AttendanceReport.Core.Repositories;
using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceReport.Repositories
{
    interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IStudentRepository StudentRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }
        IOfferedRepository OfferedRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }


        IEnumerable<StudentAttendanceViewModel> GetByCourse(OfferedViewModel offered);
        IEnumerable<StudentAttendanceViewModel> GetByStudent(StudentViewModel student);
        StudentAttendanceViewModel GetByStudentCourse(StudentViewModel student, OfferedViewModel offered);
      /*  OfferedViewModel GetOfferedById(string id);
        StudentViewModel GetStudentById(string id);
        UserViewModel GetUser(string login, string password);
        UserViewModel GetUserById(string login);
        IEnumerable<OfferedViewModel> GetOfferedByFacultyID(int facultyId);
        IEnumerable<EnrollmentViewModel> GetEnrollmentByStudentID(string studentId);
        IEnumerable<UserViewModel> FindAllUser(string id);
        bool InsertUser(UserViewModel user);
        bool DeleteUser(UserViewModel user);*/
        int Complete();
    }
}
