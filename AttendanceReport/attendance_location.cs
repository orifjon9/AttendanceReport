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
    
    public partial class attendance_location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public attendance_location()
        {
            this.attendance_record = new HashSet<attendance_record>();
        }
    
        public string Id { get; set; }
        public string Building { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attendance_record> attendance_record { get; set; }
    }
}
