namespace ExamServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTournament")]
    public partial class tblTournament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTournament()
        {
            tblJudge = new HashSet<tblJudge>();
            tblProject = new HashSet<tblProject>();
            tblQuestionaire = new HashSet<tblQuestionaire>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldTournamentID { get; set; }

        [StringLength(150)]
        public string fldTournamentName { get; set; }

        public int? fldYear { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fldStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fldEndDate { get; set; }

        [StringLength(25)]
        public string fldStartTime { get; set; }

        [StringLength(150)]
        public string fldAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblJudge> tblJudge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblQuestionaire> tblQuestionaire { get; set; }
    }
}
