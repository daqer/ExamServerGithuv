//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTeam
    {
        public long fldTeamID { get; set; }
        public Nullable<int> fldProjectID { get; set; }
        public Nullable<long> fldLoginID { get; set; }
        public string fldTeamName { get; set; }
        public string fldTopic { get; set; }
        public Nullable<int> fldMembers { get; set; }
        public string fldLeaderName { get; set; }
    
        public virtual tblLogin tblLogin { get; set; }
        public virtual tblProject tblProject { get; set; }
    }
}
