using AttendanceReport.Core.Repositories;
using AttendanceReport.Models;
using AttendanceReport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceReport.Persistence.Repositories
{
    public class StudentRepository : Repository<student>, IStudentRepository
    {
        private AttendanceDBEntities context;

        public StudentRepository(AttendanceDBEntities context) : base(context)
        {
            this.context = context;
        }
        
        public StudentViewModel GetById(string id)
        {
            return (StudentViewModel)this.Find(student=> student.StudentId == id).FirstOrDefault();
        }

        public IEnumerable<StudentViewModel> GetByOfferedId(int offerId)
        {
            return context.enrollments
                .Where(w => w.OfferId == offerId).ToList()
                .Select(s => (StudentViewModel)s.student);
        }
    }
}