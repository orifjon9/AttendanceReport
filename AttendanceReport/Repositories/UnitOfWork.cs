using AttendanceReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private AttendanceDBEntities context = new AttendanceDBEntities();
        private bool disposed = false;
        
        private UserRepository userRepository;
        protected UserRepository UserRepository {
            get {
                if (this.userRepository == null)
                    this.userRepository = new UserRepository(this.context);

                return this.userRepository;
            }
        }

        private StudentRepository studentRepository;
        protected StudentRepository StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                    this.studentRepository = new StudentRepository(this.context);

                return this.studentRepository;
            }
        }

        private EnrollmentRepository enrollmentRepository;
        protected EnrollmentRepository EnrollmentRepository
        {
            get
            {
                if (this.enrollmentRepository == null)
                    this.enrollmentRepository = new EnrollmentRepository(this.context);

                return this.enrollmentRepository;
            }
        }

        private OfferedRepository offeredRepository;
        protected OfferedRepository OfferedRepository
        {
            get
            {
                if (this.offeredRepository == null)
                    this.offeredRepository = new OfferedRepository(this.context);

                return this.offeredRepository;
            }
        }

        private AttendanceRepository attendanceRepository;
        protected AttendanceRepository AttendanceRepository
        {
            get
            {
                if (this.attendanceRepository == null)
                    this.attendanceRepository = new AttendanceRepository(this.context);

                return this.attendanceRepository;
            }
        }



        public List<StudentAttendanceViewModel> GetByCourse(OfferedViewModel offered)
        {
            var records = new List<StudentAttendanceViewModel>();
            var block = context.attendance_block
                .Where(w => w.BeginDate == offered.StartDate)
                .FirstOrDefault();

            if (block != null)
            {
                var sessions = block.attendance_session
                    .Where(w => w.TimeslotId == "AM")
                    .Select(s => new SessionViewModel(s)).ToList();

                foreach (var student in StudentRepository.GetByOfferedId(offered.Id))
                {
                    var studentAttendanceViewModel = new StudentAttendanceViewModel();
                    studentAttendanceViewModel.Student = student;
                    studentAttendanceViewModel.CourseOffered = offered;
                    studentAttendanceViewModel.Sessions = sessions;
                    studentAttendanceViewModel.AttendanceRecords = GetAttendanceRecords(student.Barcode, block.BeginDate, block.EndDate);
                    records.Add(studentAttendanceViewModel);
                }
            }

            return records;
        }

        public List<StudentAttendanceViewModel> GetByStudent(StudentViewModel student)
        {
            var records = new List<StudentAttendanceViewModel>();
            var offereds = OfferedRepository.GetByStudentID(student.StudentId);

            if (offereds != null)
            {
                foreach (var offered in offereds)
                {
                    attendance_block block = context.attendance_block
                            .Where(w => w.BeginDate == offered.StartDate)
                            .FirstOrDefault();

                    if (block == null) continue;

                    var sessions = block.attendance_session
                        .Where(w => w.TimeslotId == "AM")
                        .ToList().Select(s => new SessionViewModel(s)).ToList();

                    var studentAttendanceViewModel = new StudentAttendanceViewModel();
                    studentAttendanceViewModel.Student = student;
                    studentAttendanceViewModel.CourseOffered = offered;
                    studentAttendanceViewModel.Sessions = sessions;
                    studentAttendanceViewModel.AttendanceRecords = GetAttendanceRecords(student.Barcode, block.BeginDate, block.EndDate);
                    records.Add(studentAttendanceViewModel);
                }
            }

            return records;
        }

        public StudentAttendanceViewModel GetByStudentCourse(StudentViewModel student, OfferedViewModel offered)
        {
            var record = new StudentAttendanceViewModel();

            attendance_block block = context.attendance_block
                            .Where(w => w.BeginDate == offered.StartDate)
                            .FirstOrDefault();

            if (block != null)
            {
                var sessions = block.attendance_session.Where(w => w.TimeslotId == "AM").ToList().Select(s => new SessionViewModel(s)).ToList();

                record.Student = student;
                record.CourseOffered = offered;
                record.Sessions = sessions;
                record.AttendanceRecords = GetAttendanceRecords(student.Barcode, block.BeginDate, block.EndDate);
            }

            return record;
        }

        private List<AttendanceRecordViewModel> GetAttendanceRecords(String barcode, DateTime startDate, DateTime endDate)
        {
            return AttendanceRepository.GetAll()
                .Where(w => w.Barcode == barcode && (w.Date >= startDate && w.Date <= endDate) && w.Timeslot == "AM" && w.Location == "DB")
                .Select(s=>s).ToList();
        }


        public OfferedViewModel GetOfferedById(string id) {
            return OfferedRepository.GetById(id);
        }

        public StudentViewModel GetStudentById(string id)
        {
            return StudentRepository.GetById(id);
        }

        public UserViewModel GetUser(string login, string password) {
             return UserRepository.GetUser(login, password);
        }

        public UserViewModel GetUserById(string login)
        {
            return UserRepository.GetById(login);
        }

        public List<OfferedViewModel> GetOfferedByFacultyID(int facultyId)
        {
            return OfferedRepository.GetByFacultyID(facultyId);
        }

        public List<EnrollmentViewModel> GetEnrollmentByStudentID(string studentId)
        {
            return EnrollmentRepository.GetByStudentID(studentId);
        }

        public List<UserViewModel> FindAllUser(string id)
        {
            return UserRepository.FindAll(id).ToList();
        }


        public bool InsertUser(UserViewModel user) {
            return UserRepository.Insert(user);
        }
        public bool DeleteUser(UserViewModel user)
        {
            return UserRepository.Delete(user);
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