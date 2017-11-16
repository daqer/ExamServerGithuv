namespace ExamServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblJudge")]
    public partial class tblJudge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblJudge()
        {
            tblAnswer = new HashSet<TblAnswer>();
        }

        [Key]
        public long fldJudgeID { get; set; }

        public int? fldTournamentID { get; set; }

        [Required]
        [StringLength(1)]
        public string fldJudgeLetter { get; set; }

        [Required]
        [StringLength(50)]
        public string fldPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAnswer> tblAnswer { get; set; }

        public virtual tblTournament tblTournament { get; set; }
    }
}
