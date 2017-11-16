namespace ExamServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblQuestionaire")]
    public partial class tblQuestionaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblQuestionaire()
        {
            tblAnswer = new HashSet<TblAnswer>();
        }

        [Key]
        public long fldQuestionaireID { get; set; }

        public int? fldTournamentID { get; set; }

        public string fldFirstQuestion { get; set; }

        public string fldSecondQuestion { get; set; }

        public string fldThirdQuestion { get; set; }

        public string fldFourthQuestion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAnswer> tblAnswer { get; set; }

        public virtual tblTournament tblTournament { get; set; }
    }
}
