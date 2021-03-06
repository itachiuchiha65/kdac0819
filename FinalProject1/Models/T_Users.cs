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
    
    public partial class T_Users
    {
        public T_Users()
        {
            this.T_DeptDetails = new HashSet<T_DeptDetails>();
            this.T_EmployeeDetails = new HashSet<T_EmployeeDetails>();
            this.T_OTP_Details = new HashSet<T_OTP_Details>();
            this.T_PasswordHistoryLog = new HashSet<T_PasswordHistoryLog>();
            this.T_TimeLog = new HashSet<T_TimeLog>();
        }
    
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public bool IsOnline { get; set; }
        public bool IsLocked { get; set; }
        public int RoleId { get; set; }
    
        public virtual ICollection<T_DeptDetails> T_DeptDetails { get; set; }
        public virtual ICollection<T_EmployeeDetails> T_EmployeeDetails { get; set; }
        public virtual ICollection<T_OTP_Details> T_OTP_Details { get; set; }
        public virtual ICollection<T_PasswordHistoryLog> T_PasswordHistoryLog { get; set; }
        public virtual T_Roles T_Roles { get; set; }
        public virtual ICollection<T_TimeLog> T_TimeLog { get; set; }
    }
}
