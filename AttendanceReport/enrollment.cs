//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class enrollment
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> OfferId { get; set; }
        public string StudentId { get; set; }
    
        public virtual offered offered { get; set; }
        public virtual student student { get; set; }
    }
}
