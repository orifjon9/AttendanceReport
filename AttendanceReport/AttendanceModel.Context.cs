﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AttendanceReport
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AttendanceDBEntities1 : DbContext
    {
        public AttendanceDBEntities1()
            : base("name=AttendanceDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<attendance_block> attendance_block { get; set; }
        public virtual DbSet<attendance_location> attendance_location { get; set; }
        public virtual DbSet<attendance_record> attendance_record { get; set; }
        public virtual DbSet<attendance_session> attendance_session { get; set; }
        public virtual DbSet<attendance_timeslot> attendance_timeslot { get; set; }
        public virtual DbSet<cours> courses { get; set; }
        public virtual DbSet<enrollment> enrollments { get; set; }
        public virtual DbSet<faculty> faculties { get; set; }
        public virtual DbSet<offered> offereds { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<userrole> userroles { get; set; }
    }
}
