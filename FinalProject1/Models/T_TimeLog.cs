//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_TimeLog
    {
        public Nullable<int> EmpId { get; set; }
        public Nullable<System.DateTime> TodayDate { get; set; }
        public Nullable<System.TimeSpan> LoggedIn { get; set; }
        public Nullable<System.TimeSpan> LoggedOut { get; set; }
        public string AttendanceStatus { get; set; }
        public Nullable<int> UserId { get; set; }
        public int AttendanceId { get; set; }
        public string WorkingHours { get; set; }
    
        public virtual T_EmployeeDetails T_EmployeeDetails { get; set; }
        public virtual T_Users T_Users { get; set; }
    }
}
