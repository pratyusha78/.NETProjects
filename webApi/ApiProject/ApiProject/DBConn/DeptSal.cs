//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiProject.DBConn
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeptSal
    {
        public int Id { get; set; }
        public Nullable<int> sal { get; set; }
        public string dept { get; set; }
        public Nullable<int> DeptEmpId { get; set; }
    
        public virtual Dept Dept1 { get; set; }
    }
}
