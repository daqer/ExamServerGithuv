namespace ExamServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAnswer")]
    public partial class TblAnswer
    {
        [Key]
        public long FldAnswerID { get; set; }

        public long? FldQuestionaireID { get; set; }

        public long? FldJudgeID { get; set; }

        public int FldFirstQuestionScore { get; set; }

        public int FldSecondQuestionScore { get; set; }

        public int FldThirdQuestionScore { get; set; }

        public int FldFourthQuestionScore { get; set; }

        public virtual tblJudge TblJudge { get; set; }

        public virtual tblQuestionaire TblQuestionaire { get; set; }
    }
}
