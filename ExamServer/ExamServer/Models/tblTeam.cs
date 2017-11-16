namespace ExamServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTeam")]
    public partial class tblTeam
    {
        [Key]
        public long fldTeamID { get; set; }

        public int? fldProjectID { get; set; }

        [StringLength(150)]
        public string fldTeamName { get; set; }

        [StringLength(50)]
        public string fldPassword { get; set; }

        [StringLength(40)]
        public string fldTopic { get; set; }

        public int? fldMembers { get; set; }

        [StringLength(50)]
        public string fldLeaderName { get; set; }

        public virtual tblProject tblProject { get; set; }
    }
}
