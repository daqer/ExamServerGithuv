namespace ExamServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProject")]
    public partial class tblProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProject()
        {
            tblTeam = new HashSet<tblTeam>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldProjectID { get; set; }

        public int? fldTournamentID { get; set; }

        [StringLength(50)]
        public string fldProjectName { get; set; }

        [StringLength(150)]
        public string fldDescription { get; set; }

        public string fldReport { get; set; }

        public virtual tblTournament tblTournament { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTeam> tblTeam { get; set; }
    }
}
