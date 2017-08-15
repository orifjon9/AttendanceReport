using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceReport.Repositories
{
    interface IUnitOfWork
    {
        List<StudentAttendanceViewModel> GetByCourse(OfferedViewModel offered);
        List<StudentAttendanceViewModel> GetByStudent(StudentViewModel student);
        StudentAttendanceViewModel GetByStudentCourse(StudentViewModel student, OfferedViewModel offered);
        OfferedViewModel GetOfferedById(string id);
        StudentViewModel GetStudentById(string id);
        UserViewModel GetUser(string login, string password);
        UserViewModel GetUserById(string login);
        List<OfferedViewModel> GetOfferedByFacultyID(int facultyId);
        List<EnrollmentViewModel> GetEnrollmentByStudentID(string studentId);
        List<UserViewModel> FindAllUser(string id);
        bool InsertUser(UserViewModel user);
        bool DeleteUser(UserViewModel user);
        void Save();
    }
}
